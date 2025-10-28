using System.Security.Claims;
using System.Text;
using Application.Exceptions;
using Application.InputModels.DataAnalysisInputModels;
using Application.ViewModels.DataAnalysisViewModels;
using Core.Entities;
using Core.Enums;
using Core.Repositories;
using Infrastructure.Utils;

namespace Application.Services.DataAnalysis
{
    public class DataAnalysisServices(
        INutrientTablesRepository nutrientTablesRepository,
        IFertilizerTablesRepository fertilizerTablesRepository,
        ICulturesRepository culturesRepository,
        IUsersRepository usersRepository
    ) : IDataAnalysisServices
    {
        private readonly INutrientTablesRepository _nutrientTablesRepository = nutrientTablesRepository;
        private readonly IFertilizerTablesRepository _fertilizerTablesRepository = fertilizerTablesRepository;
        private readonly ICulturesRepository _culturesRepository = culturesRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<NutrientAnalysisViewModel> AnalyseNutrients(AnalyseNutrientsInputModel inputModel, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var analysisViewModel = new NutrientAnalysisViewModel
            {
                Warning = false,
                Month = inputModel.Month!
            };

            foreach (var plotInputModel in inputModel.Plots)
            {
                var plotViewModel = new PlotAnalysisViewModel
                {
                    CultureType = plotInputModel.CultureType!,
                    PlotName = plotInputModel.PlotName!,
                    ExpectedProductivity = plotInputModel.ExpectedProductivity,
                    Width = plotInputModel.Width,
                    Height = plotInputModel.Height,
                    PRNT = plotInputModel.PRNT,
                };

                var plotCulture = await _culturesRepository.GetByNameAsync(plotInputModel.CultureType!)
                    ?? throw new NotFoundException("Culture not found");

                var nutrientTable = await _nutrientTablesRepository.GetByCultureAsync(plotCulture.Id, user)
                    ?? throw new NotFoundException("Nutrient Table not found");

                var tableData = nutrientTable.GetTableData();

                NutrientRowData nutrientRow;

                //Análise foliar
                if (inputModel.SoilAnalysis == false)
                {
                    if (plotInputModel.Nutrients.ElementAt(0).Header != NutrientHeader.N)
                        throw new BadRequestException("Invalid input for foliar analysis", []);

                    string normalizedMonth = StringNormalizationService.NormalizeString(inputModel.Month)!;
                    var monthIndex = NutrientTableDivisionExtension.GetMonthIndex(normalizedMonth, nutrientTable.Division);

                    if (monthIndex == -1)
                    {
                        if (nutrientTable.Division != NutrientTableDivision.Annual)
                            analysisViewModel.Warning = true;

                        nutrientRow = tableData.LeafNutrientRows[0];
                    }
                    else
                    {
                        if (nutrientTable.Division == NutrientTableDivision.Annual)
                        {
                            nutrientRow = tableData.LeafNutrientRows[0];
                            analysisViewModel.Warning = true;
                        }
                        else
                            nutrientRow = tableData.LeafNutrientRows[monthIndex];
                    }

                    var nutrientValues = new Dictionary<string, float>();

                    AnalyseLeafNutrients(plotInputModel, nutrientRow, nutrientValues, plotViewModel);

                    AnalyseRelations(nutrientRow, nutrientValues, plotViewModel);
                }

                //Análise do Solo
                else
                {
                    if (plotInputModel.Nutrients.ElementAt(0).Header == NutrientHeader.N)
                        throw new BadRequestException("Invalid input for soil analysis", []);

                    nutrientRow = tableData.SoilNutrientRow;

                    AnalyseSoilNutrients(plotInputModel, nutrientRow, plotViewModel);
                }

                analysisViewModel.Plots.Add(plotViewModel);
            }

            return analysisViewModel;
        }

        private void AnalyseLeafNutrients
        (
            AnalysePlotInputModel plot,
            NutrientRowData nutrientRow,
            Dictionary<string, float> nutrientValues,
            PlotAnalysisViewModel plotViewModel
        )
        {
            foreach (var nutrient in plot.Nutrients)
            {
                var nutrientColumn = nutrientRow.NutrientColumns.FirstOrDefault(col => col.Header == nutrient.Header)
                    ?? throw new NotFoundException("Nutrient Column not found");

                float nutrientValue = nutrient.Value;
                float min = nutrientColumn.Min;
                float max = nutrientColumn.Max;

                nutrientValues[nutrient.Header.ToFriendlyString()] = nutrientValue;

                string analysisResult = "";

                if (nutrientValue < min)                                            //Abaixo do mínimo recomendado
                    analysisResult = "Baixo";
                else if (nutrientValue > max)                                       //Acima do máximo recomendado
                    analysisResult = "Alto";
                else if (nutrientValue <= (min + max) / 2.0)                        //Na metade inferior da faixa recomendada
                    analysisResult = "Aceitável";
                else                                                                //Na metade superior da faixa recomendada
                    analysisResult = "Adequado";

                plotViewModel.Nutrients.Add(new SingleNutrientAnalysisViewModel
                {
                    Header = nutrient.Header.ToFriendlyString(),
                    Analysis = analysisResult,
                    Value = nutrientValue
                });
            }
        }

        private void AnalyseSoilNutrients
        (
            AnalysePlotInputModel plot,
            NutrientRowData nutrientRow,
            PlotAnalysisViewModel plotViewModel
        )
        {
            foreach (var nutrient in plot.Nutrients)
            {
                var nutrientColumn = nutrientRow.NutrientColumns.FirstOrDefault(col => col.Header == nutrient.Header)
                    ?? throw new NotFoundException("Nutrient Column not found");

                float nutrientValue = nutrient.Value;
                float min = nutrientColumn.Min;
                float med1 = nutrientColumn.Med1;
                float med2 = nutrientColumn.Med2;
                float max = nutrientColumn.Max;
                bool inverted = nutrientColumn.Inverted;

                string analysisResult = "";

                if (med1 != 0 && med2 != 0)
                {
                    if (nutrientValue < min)
                        analysisResult = inverted ? "Muito Bom" : "Muito Baixo";
                    else if (nutrientValue < med1)
                        analysisResult = inverted ? "Bom" : "Baixo";
                    else if (nutrientValue < med2)
                        analysisResult = "Médio";
                    else if (nutrientValue < max)
                        analysisResult = inverted ? "Alto" : "Bom";
                    else
                        analysisResult = inverted ? "Muito Alto" : "Muito Bom";
                }
                else
                {
                    if (nutrientValue < min)                                            //Abaixo do mínimo recomendado
                        analysisResult = "Baixo";
                    else if (nutrientValue > max)                                       //Acima do máximo recomendado
                        analysisResult = "Alto";
                    else if (nutrientValue <= (min + max) / 2.0)                        //Na metade inferior da faixa recomendada
                        analysisResult = "Aceitável";
                    else                                                                //Na metade superior da faixa recomendada
                        analysisResult = "Adequado";
                }

                plotViewModel.Nutrients.Add(new SingleNutrientAnalysisViewModel
                {
                    Header = nutrient.Header.ToFriendlyString(),
                    Analysis = analysisResult,
                    Value = nutrientValue
                });
            }
        }

        private void AnalyseRelations
        (
            NutrientRowData nutrientRow,
            Dictionary<string, float> nutrientValues,
            PlotAnalysisViewModel plotViewModel
        )
        {
            foreach (
                var relation in new[]{
                    NutrientHeader.NP, NutrientHeader.NK, NutrientHeader.NS, NutrientHeader.NB, NutrientHeader.NCu,
                    NutrientHeader.PMg, NutrientHeader.PZn, NutrientHeader.KCa, NutrientHeader.KMg, NutrientHeader.KMn,
                    NutrientHeader.CaMg, NutrientHeader.CaMn, NutrientHeader.FeMn
                })
            {
                var nutrientColumn = nutrientRow.NutrientColumns.FirstOrDefault(col => col.Header == relation)
                    ?? throw new NotFoundException("Nutrient Column not found");

                var (nutrientA, nutrientB) = NutrientHeaderExtension.ParseRelationHeader(relation);

                float nutrientRelation = nutrientValues[nutrientA] / nutrientValues[nutrientB];
                float min = nutrientColumn.Min;
                float max = nutrientColumn.Max;

                string analysisResult = "";

                var microNutrients = new[]
                {
                    NutrientHeader.Zn,
                    NutrientHeader.B,
                    NutrientHeader.Cu,
                    NutrientHeader.Mn,
                    NutrientHeader.Fe
                };

                if (microNutrients.Contains(nutrientA.ToHeader()))
                    nutrientRelation /= 1000;
                if (microNutrients.Contains(nutrientB.ToHeader()))
                    nutrientRelation *= 1000;

                if (nutrientRelation < min)                                                 //Abaixo do mínimo recomendado
                    analysisResult = "Pouco " + nutrientA + " comparado a " + nutrientB;
                else if (nutrientRelation > max)                                            //Acima do máximo recomendado
                    analysisResult = "Muito " + nutrientA + " comparado a " + nutrientB;
                else if (nutrientRelation <= (min + max) / 2.0)                             //Na metade inferior da faixa recomendada
                    analysisResult = "Proporção aceitável, falta um pouco de " + nutrientA;
                else                                                                        //Na metade superior da faixa recomendada
                    analysisResult = "Proporção adequada";

                plotViewModel.Nutrients.Add(new SingleNutrientAnalysisViewModel
                {
                    Header = relation.ToFriendlyString(),
                    Analysis = analysisResult,
                    Value = nutrientRelation
                });
            }
        }

        public async Task<FertilizerRecomendationViewModel> RecommendFertilizers(RecommendFertilizersInputModel inputModel, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var fertilizerViewModel = new FertilizerRecomendationViewModel
            {
                SoilRecomendation = inputModel.SoilRecomendation,
                Plots = []
            };

            foreach (var plotInputModel in inputModel.Plots)
            {
                var plotViewModel = new PlotFertilizerViewModel
                {
                    CultureType = plotInputModel.CultureType!,
                    PlotName = plotInputModel.PlotName!,
                    ProductRecomendations = []
                };

                var plotCulture = await _culturesRepository.GetByNameAsync(plotInputModel.CultureType!)
                    ?? throw new NotFoundException("Culture not found");

                var fertilizerTable = await _fertilizerTablesRepository.GetByCultureAsync(plotCulture.Id, user)
                    ?? throw new NotFoundException("Nutrient Table not found");

                var tableData = fertilizerTable.GetTableData();

                if (inputModel.SoilRecomendation)
                {
                    float Vexpected = fertilizerTable.ExpectedBasesSaturation;
                    SoilRecommendation(plotInputModel, Vexpected, tableData.SoilFertilizerRows, plotViewModel);
                }
                else
                {
                    LeafRecommendation(plotInputModel, tableData.LeafFertilizerRow, plotViewModel);
                }

                fertilizerViewModel.Plots.Add(plotViewModel);
            }

            return fertilizerViewModel;
        }

        private void SoilRecommendation(FertilizerPlotInputModel inputModel, float Vexpected,  List<SoilFertilizerRowData> soilData, PlotFertilizerViewModel viewModel)
        {
            var width = inputModel.Width;
            var height = inputModel.Height;
            var PRNT = inputModel.PRNT;
            var plants = 10000 / (width * height);
            var expectedProductivity = 480 * inputModel.ExpectedProductivity / plants;

            float SB = 0, T = 0, organicMatter = 0, V = 0, nValue = 0, pValue = 0, kValue = 0, bValue = 0, calagem = 0;

            foreach (var nutrient in inputModel.Nutrients)
            {
                var header = nutrient.Header;
                if (header == NutrientHeader.SumBases.ToFriendlyString()) SB = nutrient.Value;
                else if (header == NutrientHeader.CTCpH7.ToFriendlyString()) T = nutrient.Value;
                else if (header == NutrientHeader.OrganicMatter.ToFriendlyString()) organicMatter = nutrient.Value;
                else if (header == NutrientHeader.BasesSaturation.ToFriendlyString()) V = nutrient.Value;
            }


            var selectedSoilData = soilData.FirstOrDefault(d => expectedProductivity < d.ExpectedProductivity);
            if (selectedSoilData == null) return;

            var nCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.N);
            if (nCol != null)
            {
                nValue = (organicMatter < 3 ? nCol.Value1 : nCol.Value2) * plants / 1000;
            }

            foreach (var nutrient in inputModel.Nutrients)
            {
                var header = nutrient.Header;
                if (header == NutrientHeader.P.ToFriendlyString())
                {
                    var pCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.P);
                    if (pCol != null)
                    {
                        if (nutrient.Value <= 10) pValue = pCol.Value1 * plants / 1000;
                        else if (nutrient.Value > 10 && nutrient.Value < 20) pValue = pCol.Value2 * plants / 1000;
                    }
                }
                else if (header == NutrientHeader.K.ToFriendlyString())
                {
                    var kCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.K);
                    if (kCol != null)
                    {
                        var perc = nutrient.Value / T * 100;
                        if (perc < 3) kValue = kCol.Value1 * plants / 1000;
                        else if (perc >= 3 && perc < 5) kValue = kCol.Value2 * plants / 1000;
                        else if (perc >= 5 && perc < 7) kValue = kCol.Value3 * plants / 1000;
                    }
                }
                else if (header == NutrientHeader.B.ToFriendlyString())
                {
                    var bCol = soilData[0].SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.B);
                    if (bCol != null)
                    {
                        if (nutrient.Analysis == "Baixo") { bValue = bCol.Value1; }
                        else if (nutrient.Analysis == "Aceitável") { bValue = bCol.Value2; }
                        else if (nutrient.Analysis == "Adequado") { bValue = bCol.Value3; }
                    }
                }
            }

            if (V < Vexpected && T > 0)
            {
                calagem = (Vexpected - V) * T / PRNT;
                if (calagem < 0) calagem = 0;
            }

            var recommendationProduct = GenerateIntegratedRecommendation(nValue, pValue, kValue, bValue ,calagem);
            if (recommendationProduct != null)
            {
                viewModel.ProductRecomendations.Add(recommendationProduct);
            }
        }

        private class FertilizerInfo
        {
            public string Name { get; set; } = string.Empty;
            public double N { get; set; }
            public double P2O5 { get; set; }
            public double K2O { get; set; }
            public double B { get; set; }
        }

        private class RecommendationItem
        {
            public string FertilizerName { get; set; } = string.Empty;
            public double DoseKgHa { get; set; }
        }

        private ProductRecomendationViewModel GenerateIntegratedRecommendation(float nNeed, float pNeed, float kNeed, float bNeed, float limingNeed)
        {
            if (nNeed <= 1 && pNeed <= 1 && kNeed <= 1 && limingNeed <= 0 && bNeed <= 1)
            {
                return new ProductRecomendationViewModel
                {
                    Name = "Plano de Fertilização",
                    Recommendation = new RecommendationViewModel
                    {
                    }
                };
            }

            var recommendationData = new RecommendationViewModel
            {
                Diagnosis = new DiagnosisSectionViewModel
                {
                    Description = "Com base na sua análise de solo e produtividade esperada, calculamos as seguintes necessidades anuais por hectare:",
                    Needs = new List<NutrientNeedViewModel>()
                },
                Plan = new PlanSectionViewModel
                {
                    Description = "Recomendamos o seguinte plano de aplicação anual:",
                    Steps = new List<ApplicationStepViewModel>()
                },
                Balance = new List<NutrientBalanceViewModel>(),
            };

            if (nNeed > 1) recommendationData.Diagnosis.Needs.Add(new NutrientNeedViewModel { Name = "Nitrogênio (N)", Value = $"{nNeed:F0} kg/ha" });
            if (pNeed > 1) recommendationData.Diagnosis.Needs.Add(new NutrientNeedViewModel { Name = "Fósforo (P₂O₅)", Value = $"{pNeed:F0} kg/ha" });
            if (kNeed > 1) recommendationData.Diagnosis.Needs.Add(new NutrientNeedViewModel { Name = "Potássio (K₂O)", Value = $"{kNeed:F0} kg/ha" });
            
            if (limingNeed > 0) recommendationData.Diagnosis.Needs.Add(new NutrientNeedViewModel { Name = "Calcário", Value = $"{limingNeed:F2} t/ha" });

            if (bNeed > 1)
            {
                recommendationData.Diagnosis.Needs.Add(new NutrientNeedViewModel { Name = "Boro(B)", Value = $"{bNeed:F0} kg/ha" });
            }
            

            var simpleFertilizers = new Dictionary<string, FertilizerInfo>();

            simpleFertilizers["N"] = new FertilizerInfo { Name = "Ureia (45% N)", N = 0.45 };
            simpleFertilizers["P"] = new FertilizerInfo { Name = "Superfosfato Simples (SSP)", P2O5 = 0.18 };
            simpleFertilizers["K"] = new FertilizerInfo { Name = "Cloreto de Potássio (KCL)", K2O = 0.60 };
            simpleFertilizers["B"] = new FertilizerInfo { Name = "Ulexita", B = 0.1 };

            var correctionStep = new ApplicationStepViewModel { Title = "Correção do Solo", Details = new List<string>() };

            double bSupplied = 0;

            if (bNeed > 1)
            {
                bSupplied = bNeed / simpleFertilizers["B"].B;
            }
            else
                correctionStep.Details.Add("Boro: Não é necessária a aplicação de boro.");
            
            if (limingNeed > 0)
                correctionStep.Details.Add($"Calagem: Aplicar {limingNeed:F2} t/ha de calcário para elevar a Saturação por Bases (V%) ao nível ideal de 70%.");
            else
                correctionStep.Details.Add("Calagem: Não é necessária.");

            
            recommendationData.Plan.Steps.Add(correctionStep);

            var npkStep = new ApplicationStepViewModel { Title = "Fertilização NPK", Details = new List<string>() };
            List<RecommendationItem> finalPlan = new List<RecommendationItem>();
            

            int nutrientsNeededCount = (nNeed > 1 ? 1 : 0) + (pNeed > 1 ? 1 : 0) + (kNeed > 1 ? 1 : 0);

            if (nutrientsNeededCount == 0)
            {
                npkStep.Details.Add("Não é necessária a aplicação de fertilizantes NPK.");
            }
            else if (nutrientsNeededCount == 1)
            {
                npkStep.Details.Add("Como a necessidade se concentra em apenas um nutriente, a recomendação é utilizar uma fonte simples.");
                if (nNeed > 1 && simpleFertilizers.ContainsKey("N"))
                    finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["N"].Name, DoseKgHa = nNeed / simpleFertilizers["N"].N });
                else if (pNeed > 1 && simpleFertilizers.ContainsKey("P"))
                    finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["P"].Name, DoseKgHa = pNeed / simpleFertilizers["P"].P2O5 });
                else if (kNeed > 1 && simpleFertilizers.ContainsKey("K"))
                    finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["K"].Name, DoseKgHa = kNeed / simpleFertilizers["K"].K2O });
            }
            else
            {
                FertilizerInfo? bestFormula = null;
                double bestFormulaDose = 0;
                double bestScore = double.MaxValue;
                
                var nLevels = new[] { 20, 25, 30 };
                var pLevels = new[] { 0, 5, 10 };
                var kLevels = new[] { 0, 5, 10, 15, 20 };

                if (nNeed > 1)
                {
                    foreach (var nPercent in nLevels)
                    {
                        double doseBasedOnN = nNeed / (nPercent / 100.0);
                        foreach (var pPercent in pLevels)
                        {
                            foreach (var kPercent in kLevels)
                            {
                                if (pNeed < 1 && pPercent > 0) continue;
                                if (kNeed < 1 && kPercent > 0) continue;
                                
                                double pSupplied = doseBasedOnN * (pPercent / 100.0);
                                double kSupplied = doseBasedOnN * (kPercent / 100.0);

                                double concentrationScore = nPercent + pPercent + kPercent;
                                double deviationScore = Math.Round(Math.Abs(pSupplied - pNeed) + Math.Abs(kSupplied - kNeed));
                                
                                double pDeficit = pNeed - pSupplied;
                                double kDeficit = kNeed - kSupplied;
                                
                                double supplementPenalty = 0;

                                if (pDeficit > pNeed * 0.1)
                                {
                                    supplementPenalty += 500;
                                }

                                if (kDeficit > kNeed * 0.1)
                                {
                                    supplementPenalty += 500;
                                }

                                double finalScore = (concentrationScore * 3) + deviationScore + supplementPenalty;
                                    
                                if (finalScore < bestScore)
                                {
                                    bestScore = finalScore;
                                    bestFormula = new FertilizerInfo
                                    {
                                        Name = $"NPK {nPercent}-{pPercent}-{kPercent}",
                                        N = nPercent / 100.0, P2O5 = pPercent / 100.0, K2O = kPercent / 100.0
                                    };
                                    bestFormulaDose = doseBasedOnN;
                                }
                            }
                        }
                    }
                }

                if (bestFormula != null)
                {
                    npkStep.Details.Add($"O formulado recomendado é o {bestFormula.Name}. Esta opção representa o melhor balanço entre um bom ajuste nutricional e a viabilidade comercial. O plano de aplicação é:");
                    finalPlan.Add(new RecommendationItem { FertilizerName = bestFormula.Name, DoseKgHa = bestFormulaDose });
                }
                else
                {
                    npkStep.Details.Add("Não foi encontrada uma fórmula NPK adequada com base na necessidade de Nitrogênio. Recomenda-se o uso de fontes simples para atender às necessidades de cada nutriente individualmente:");
                    if (nNeed > 1 && simpleFertilizers.ContainsKey("N")) finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["N"].Name, DoseKgHa = nNeed / simpleFertilizers["N"].N });
                    if (pNeed > 1 && simpleFertilizers.ContainsKey("P")) finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["P"].Name, DoseKgHa = pNeed / simpleFertilizers["P"].P2O5 });
                    if (kNeed > 1 && simpleFertilizers.ContainsKey("K")) finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["K"].Name, DoseKgHa = kNeed / simpleFertilizers["K"].K2O });
                }
            }

            finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["B"].Name, DoseKgHa = bSupplied });

            if (finalPlan.Any())
            {
                foreach (var item in finalPlan.Where(i => i.DoseKgHa > 0.1))
                {
                    npkStep.Details.Add($"{item.FertilizerName}: {item.DoseKgHa:F1} kg/ha");
                }
            }

            recommendationData.Plan.Steps.Add(npkStep);

            if (finalPlan.Any())
            {
                var allFertilizers = new List<FertilizerInfo>();
                var bestFormulaInPlan = finalPlan.FirstOrDefault(item => item.FertilizerName.StartsWith("NPK"));
                if(bestFormulaInPlan != null)
                {
                    var parts = bestFormulaInPlan.FertilizerName.Replace("NPK ", "").Split('-');
                    if(parts.Length == 3)
                    {
                        allFertilizers.Add(new FertilizerInfo {
                            Name = bestFormulaInPlan.FertilizerName,
                            N = double.Parse(parts[0]) / 100.0, P2O5 = double.Parse(parts[1]) / 100.0, K2O = double.Parse(parts[2]) / 100.0
                        });
                    }
                }

                allFertilizers.AddRange(simpleFertilizers.Values);

                double totalNApplied = 0, totalPApplied = 0, totalKApplied = 0, totoalBApplied = bSupplied * simpleFertilizers["B"].B;
                
                foreach (var item in finalPlan)
                {
                    var fertilizerInfo = allFertilizers.FirstOrDefault(f => f.Name == item.FertilizerName);
                    if (fertilizerInfo != null)
                    {
                        totalNApplied += item.DoseKgHa * fertilizerInfo.N;
                        totalPApplied += item.DoseKgHa * fertilizerInfo.P2O5;
                        totalKApplied += item.DoseKgHa * fertilizerInfo.K2O;
                    }
                }
                
                Action<string, double, double> addBalanceItem = (nutrientName, applied, needed) => {
                    if (needed <= 1 && applied <= 1) return;
                    double balance = applied - needed;
                    string result = Math.Abs(balance) < 1.0 ? "Atendido" : (balance > 0 ? "Excesso" : "Déficit");
                    string balanceText = Math.Abs(balance) < 1.0 ? $"{balance:F1} kg/ha" : (balance > 0 ? $"+{balance:F1} kg/ha" : $"{balance:F1} kg/ha");
                    
                    recommendationData.Balance.Add(new NutrientBalanceViewModel {
                        Name = nutrientName, Applied = $"{applied:F0} kg/ha", Needed = $"{needed:F0} kg/ha", Result = result, Balance = balanceText
                    });
                };

                addBalanceItem("Boro (B)", totoalBApplied, bNeed);
                addBalanceItem("Nitrogênio (N)", totalNApplied, nNeed);
                addBalanceItem("Fósforo (P₂O₅)", totalPApplied, pNeed);
                addBalanceItem("Potássio (K₂O)", totalKApplied, kNeed);
            }
            
            double totalAnnualDose = finalPlan.Sum(item => item.DoseKgHa);

            if (totalAnnualDose > 1)
            {
                int GetParcels(double dose)
                {
                    if (dose > 1500) return 4;
                    else if (dose > 1000) return 3;
                    else if (dose > 500) return 2;
                    else return 1;
                }

                int maxParcels = finalPlan
                    .Select(item => GetParcels(item.DoseKgHa))
                    .DefaultIfEmpty(1)
                    .Max();

                recommendationData.Installments = new InstallmentViewModel
                {
                    TotalAnnualDose = $"{totalAnnualDose:F0} kg/ha",
                    NumberOfInstallments = maxParcels, 
                    Description = $"A dose total de fertilizantes é de {totalAnnualDose:F0} kg/ha. " +
                                $"Recomendamos dividir a aplicação em {maxParcels} parcelas para otimizar a absorção dos nutrientes.",
                    Details = finalPlan.Where(i => i.DoseKgHa > 0.1).Select(item =>
                    {
                        int nutrientParcels = GetParcels(item.DoseKgHa); 
                        return new InstallmentDetailViewModel
                        {
                            FertilizerName = item.FertilizerName,
                            DosePerInstallment = $"{nutrientParcels} {(nutrientParcels > 1 ? " parcelas" : " parcela")} de {item.DoseKgHa / nutrientParcels:F1} kg/ha"
                        };
                    }).ToList()
                };
            }

            return new ProductRecomendationViewModel
            {
                Name = "Plano de Fertilização e Correção de Solo",
                Recommendation = recommendationData
            };
        }

        private void LeafRecommendation(FertilizerPlotInputModel inputModel, LeafFertilizerRowData leafData, PlotFertilizerViewModel viewModel)
        {
            var leafRecData = new LeafRecommendationViewModel();
            var adequateNutrients = new List<string>();

            foreach (var nutrient in inputModel.Nutrients)
            {
                
                if (nutrient.Analysis == "Adequado")
                {
                    adequateNutrients.Add(nutrient.Header);
                }
                
                if (nutrient.Header == NutrientHeader.S.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Zn.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.B.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Mn.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Fe.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Cu.ToFriendlyString())
                {
                    
                    if (nutrient.Analysis == "Baixo" || nutrient.Analysis == "Aceitável")
                    {
                        var data = leafData.LeafFertilizerColumns
                                        .FirstOrDefault(d => d.Header.ToFriendlyString() == nutrient.Header);

                        if (data == null || !data.Products.Any()) continue;

                        var correction = new CorrectionViewModel
                        {
                            NutrientName = nutrient.Header,
                            DiagnosisLevel = $"Nível {nutrient.Analysis}"
                        };

                        int productCount = data.Products.Count();
                        correction.RecommendedActionTitle = productCount > 1
                            ? "Para corrigir esta deficiência, sugerimos uma das seguintes opções:"
                            : "A recomendação para corrigir esta deficiência é a seguinte:";

                        foreach (var product in data.Products)
                        {
                            string dose = nutrient.Analysis == "Baixo"
                                ? product.MaxConcentration.ToString()
                                : product.MinConcentration.ToString();
                            string unit = product.Solid ? "Kg" : "L";
                            correction.ProductOptions.Add(new ProductOptionViewModel
                            {
                                Name = product.Name,
                                RecommendationText = $"{dose}{unit} por 400L de água."
                            });
                        }
                        leafRecData.Corrections.Add(correction);
                    }
                }
            }

            if (adequateNutrients.Count() > 1)
            {
                leafRecData.Maintenance = new MaintenanceViewModel
                {
                    Title = "Manutenção Nutricional",
                    AdequateNutrients = adequateNutrients,
                    RecommendationText = "Para manter estes nutrientes em níveis ótimos, considere a aplicação de um fertilizante foliar misto de forma preventiva. Siga sempre a dose e a recomendação do fabricante do produto."
                };
            }
            
            
            if (leafRecData.Corrections.Any() || leafRecData.Maintenance != null)
            {
                viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel
                {
                    Name = "Recomendação Foliar",
                    LeafRecommendation = leafRecData
                });
            }
        }
    }       
}