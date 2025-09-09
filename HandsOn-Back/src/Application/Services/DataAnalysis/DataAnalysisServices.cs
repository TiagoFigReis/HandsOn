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
        IFormulationTablesRepository formulationTableRepository,
        ICulturesRepository culturesRepository,
        IUsersRepository usersRepository
    ) : IDataAnalysisServices
    {
        private readonly INutrientTablesRepository _nutrientTablesRepository = nutrientTablesRepository;
        private readonly IFertilizerTablesRepository _fertilizerTablesRepository = fertilizerTablesRepository;
        private readonly IFormulationTablesRepository _formulationTableRepository = formulationTableRepository;
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
                    PlotName = plotInputModel.PlotName!
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

                var formulationTable = await _formulationTableRepository.GetByCultureAsync(plotCulture.Id, user)
                    ?? throw new NotFoundException("Formulation Table not found");;

                var tableData = fertilizerTable.GetTableData();
                var formulationTableData = formulationTable.GetTableData();

                if (inputModel.SoilRecomendation)
                {
                    SoilRecommendation(plotInputModel, tableData.SoilFertilizerRows, formulationTableData, plotViewModel);
                }
                else
                {
                    LeafRecommendation(plotInputModel, tableData.LeafFertilizerRow, plotViewModel);
                }

                fertilizerViewModel.Plots.Add(plotViewModel);
            }

            return fertilizerViewModel;
        }

        private void SoilRecommendation(FertilizerPlotInputModel inputModel, List<SoilFertilizerRowData> soilData, FormulationTableData formulationData, PlotFertilizerViewModel viewModel)
        {
            var width = inputModel.Spacing.Width;
            var height = inputModel.Spacing.Height;
            var plants = 10000 / (width * height);
            var expectedProductivity = 480 * inputModel.ExpectedProductivity / plants;

            float SB = 0, T = 0, organicMatter = 0, V = 0;
            const float Vexpected = 70;

            float nValue = 0, pValue = 0, kValue = 0;

            foreach (var nutrient in inputModel.Nutrients)
            {
                var header = nutrient.Header;

                if (header == NutrientHeader.SumBases.ToFriendlyString())
                    SB = nutrient.Value;
                else if (header == NutrientHeader.CTCpH7.ToFriendlyString())
                    T = nutrient.Value;
                else if (header == NutrientHeader.OrganicMatter.ToFriendlyString())
                    organicMatter = nutrient.Value;
                else if (header == NutrientHeader.BasesSaturation.ToFriendlyString())
                    V = nutrient.Value;
            }

            var selectedSoilData = soilData.FirstOrDefault(d => expectedProductivity < d.ExpectedProductivity);
            if (selectedSoilData == null) return;
            
            void AddRecommendation(string name, string text) =>
                viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel { Name = name, Recomendation = text });

            var nCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.N);
            if (nCol != null)
            {
                nValue = (organicMatter < 3 ? nCol.Value1 : nCol.Value2) * plants / 1000;
                AddRecommendation("Nitrogênio (N)", $"Pode-se utilizar {nValue:F0} kg/ha/ano de Nitrogênio (N)");
            }
            
            foreach (var nutrient in inputModel.Nutrients)
            {
                var header = nutrient.Header;

                if (header == NutrientHeader.P.ToFriendlyString())
                {
                    var pCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.P);
                    if (pCol != null)
                    {
                        if (nutrient.Value <= 10)
                            pValue = pCol.Value1 * plants / 1000;
                        else if (nutrient.Value > 10 && nutrient.Value < 20)
                            pValue = pCol.Value2 * plants / 1000;

                        if (pValue > 0)
                            AddRecommendation("Fósforo (P₂O₅)", $"Pode-se utilizar {pValue:F0} kg/ha/ano de P₂O₅");
                        else
                            AddRecommendation("Fósforo (P₂O₅)", "Não é necessário aplicação desse nutriente");
                    }
                }
                else if (header == NutrientHeader.K.ToFriendlyString())
                {
                    var kCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.K);
                    if (kCol != null)
                    {
                        var perc = nutrient.Value / T * 100;
                        if (perc < 3)
                            kValue = kCol.Value1 * plants / 1000;
                        else if (perc >= 3 && perc < 5)
                            kValue = kCol.Value2 * plants / 1000;
                        else if (perc >= 5 && perc < 7)
                            kValue = kCol.Value3 * plants / 1000;

                        if (kValue > 0)
                            AddRecommendation("Potássio (K₂O)", $"Pode-se utilizar {kValue:F0} kg/ha/ano de K₂O ");
                        else
                            AddRecommendation("Potássio (K₂O)", "Não é necessário aplicação desse nutriente");
                    }
                }
                else if (header == NutrientHeader.B.ToFriendlyString())
                {
                    var bCol = soilData[0].SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.B);
                    if (bCol != null)
                    {
                        string rec = "Não é necessário correção desse nutriente";
                        if (nutrient.Analysis == "Baixo")
                            rec = $"Pode-se utilizar {bCol.Value1} kg/ha de Boro (B)";
                        else if (nutrient.Analysis == "Aceitável")
                            rec = $"Pode-se utilizar {bCol.Value2} kg/ha de Boro (B)";
                        else if (nutrient.Analysis == "Adequado")
                            rec = $"Pode-se utilizar {bCol.Value3} kg/ha de Boro (B)";
                        AddRecommendation("Boro (B)", rec);
                    }
                }
            }

            if (V < Vexpected)
            {
                var calagem = Vexpected / 100 * T - SB;
                AddRecommendation("Calagem", $"Pode-se utilizar {calagem:F2} t/ha de calcário");
            }
            else
            {
                AddRecommendation("Calagem", "Não é necessário aplicação de calcário");
            }

            AddRecommendation("Micronutrientes", "A correção de micronutrientes é predominantemente feita via foliar. Para isso é necessário uma análise de folhas para que sejam feitas recomendações");

            GenerateFormulationPlan(nValue, pValue, kValue, formulationData, viewModel);
        }
        
        private class FertilizerInfo
        {
            public string Name { get; set; } = string.Empty;
            public double N { get; set; }
            public double P2O5 { get; set; }
            public double K2O { get; set; }
        }

        private class RecommendationItem
        {
            public string FertilizerName { get; set; } = string.Empty;
            public double DoseKgHa { get; set; }
        }

        private void GenerateFormulationPlan(float nNeed, float pNeed, float kNeed, FormulationTableData formulationData, PlotFertilizerViewModel viewModel)
        {
            var simpleFertilizers = new Dictionary<string, FertilizerInfo>();
            foreach (var simple in formulationData.BasicFormulationRows.SelectMany(row => row.FormulationColumns))
            {
                if (simple.NAmount == 45) simpleFertilizers["N"] = new FertilizerInfo { Name = "Ureia", N = 0.45 };
                if (simple.PAmount == 18) simpleFertilizers["P"] = new FertilizerInfo { Name = "Superfosfato Simples (SSP)", P2O5 = 0.18 };
                if (simple.KAmount == 60) simpleFertilizers["K"] = new FertilizerInfo { Name = "Cloreto de Potássio (KCL)", K2O = 0.60 };
            }
            int nutrientsNeededCount = 0;
            if (nNeed > 1) nutrientsNeededCount++;
            if (pNeed > 1) nutrientsNeededCount++;
            if (kNeed > 1) nutrientsNeededCount++;

            if (nutrientsNeededCount == 1)
            {
                var finalPlan = new List<RecommendationItem>();
                string justification = "Como a necessidade se concentra em apenas um nutriente, a recomendação é utilizar uma fonte simples.";

                if (nNeed > 1 && simpleFertilizers.ContainsKey("N"))
                {
                    finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["N"].Name, DoseKgHa = nNeed / simpleFertilizers["N"].N });
                }
                else if (pNeed > 1 && simpleFertilizers.ContainsKey("P"))
                {
                    finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["P"].Name, DoseKgHa = pNeed / simpleFertilizers["P"].P2O5 });
                }
                else if (kNeed > 1 && simpleFertilizers.ContainsKey("K"))
                {
                    finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["K"].Name, DoseKgHa = kNeed / simpleFertilizers["K"].K2O });
                }

                if (finalPlan.Any())
                {
                    var recomendationText = new StringBuilder();
                    double totalAnnualDose = finalPlan.Sum(item => item.DoseKgHa);
                    
                    int numberOfParcels = 1;
                    if (totalAnnualDose > 1500) numberOfParcels = 4;
                    else if (totalAnnualDose > 1000) numberOfParcels = 3;
                    else if (totalAnnualDose > 500) numberOfParcels = 2;

                    recomendationText.AppendLine($"**{justification}**");
                    recomendationText.AppendLine("\n**Aplicação Anual Total:**");
                    foreach (var item in finalPlan)
                    {
                        recomendationText.AppendLine($"- **{item.FertilizerName}:** {item.DoseKgHa:F1} kg/ha");
                    }
                    recomendationText.AppendLine($"\n**Sugestão de Parcelamento ({numberOfParcels} aplicações):**");
                    recomendationText.AppendLine($"*Devido à dose total de {totalAnnualDose:F0} kg/ha, recomendamos dividir a aplicação em {numberOfParcels} parcelas para otimizar a absorção e reduzir perdas.*");
                    foreach (var item in finalPlan)
                    {
                        recomendationText.AppendLine($"- **{item.FertilizerName}:** {item.DoseKgHa / numberOfParcels:F1} kg/ha por aplicação");
                    }

                    viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel
                    {
                        Name = "Plano de Formulação",
                        Recomendation = recomendationText.ToString()
                    });

                    return;
                }
            }


            var commercialFormulas = formulationData.CompoundFormulationRows
                .SelectMany(row => row.FormulationColumns)
                .Select(col => new FertilizerInfo
                {
                    Name = $"NPK {col.NAmount}-{col.PAmount}-{col.KAmount}",
                    N = col.NAmount / 100.0,
                    P2O5 = col.PAmount / 100.0,
                    K2O = col.KAmount / 100.0
                }).ToList();

            if (nNeed <= 0 && pNeed <= 0 && kNeed <= 0) return;

            FertilizerInfo? bestFormula = null;
            double bestFormulaDose = 0;
            double bestOverallScore = double.MaxValue;

            foreach (var formula in commercialFormulas)
            {
                var scenarios = new List<(double dose, double totalSurplus, double totalDeficit)>();
                
                if (formula.N > 0 && nNeed > 0)
                {
                    var dose = nNeed / formula.N;
                    var surplus = Math.Max(0, (dose * formula.P2O5) - pNeed) + Math.Max(0, (dose * formula.K2O) - kNeed);
                    var deficit = Math.Max(0, pNeed - (dose * formula.P2O5)) + Math.Max(0, kNeed - (dose * formula.K2O));
                    scenarios.Add((dose, surplus, deficit));
                }
                if (formula.P2O5 > 0 && pNeed > 0)
                {
                    var dose = pNeed / formula.P2O5;
                    var surplus = Math.Max(0, (dose * formula.N) - nNeed) + Math.Max(0, (dose * formula.K2O) - kNeed);
                    var deficit = Math.Max(0, nNeed - (dose * formula.N)) + Math.Max(0, kNeed - (dose * formula.K2O));
                    scenarios.Add((dose, surplus, deficit));
                }
                if (formula.K2O > 0 && kNeed > 0)
                {
                    var dose = kNeed / formula.K2O;
                    var surplus = Math.Max(0, (dose * formula.N) - nNeed) + Math.Max(0, (dose * formula.P2O5) - pNeed);
                    var deficit = Math.Max(0, nNeed - (dose * formula.N)) + Math.Max(0, pNeed - (dose * formula.P2O5));
                    scenarios.Add((dose, surplus, deficit));
                }

                if (!scenarios.Any()) continue;
                
                var bestScenarioForThisFormula = scenarios.OrderBy(s => s.totalSurplus + s.totalDeficit).First();
                
                double currentScore = bestScenarioForThisFormula.totalDeficit + bestScenarioForThisFormula.totalSurplus;

                if (currentScore < bestOverallScore)
                {
                    bestOverallScore = currentScore;
                    bestFormula = formula;
                    bestFormulaDose = bestScenarioForThisFormula.dose;
                }
            }

            if (bestFormula == null) return;
            
            var finalPlanComplex = new List<RecommendationItem>
            {
                new RecommendationItem { FertilizerName = bestFormula.Name, DoseKgHa = bestFormulaDose }
            };
            
            double nApplied = bestFormulaDose * bestFormula.N;
            double pApplied = bestFormulaDose * bestFormula.P2O5;
            double kApplied = bestFormulaDose * bestFormula.K2O;

            double nDeficit = nNeed - nApplied;
            double pDeficit = pNeed - pApplied;
            double kDeficit = kNeed - kApplied;

            if (nDeficit > 1 && simpleFertilizers.ContainsKey("N"))
                finalPlanComplex.Add(new RecommendationItem { FertilizerName = simpleFertilizers["N"].Name, DoseKgHa = nDeficit / simpleFertilizers["N"].N });
            if (pDeficit > 1 && simpleFertilizers.ContainsKey("P"))
                finalPlanComplex.Add(new RecommendationItem { FertilizerName = simpleFertilizers["P"].Name, DoseKgHa = pDeficit / simpleFertilizers["P"].P2O5 });
            if (kDeficit > 1 && simpleFertilizers.ContainsKey("K"))
                finalPlanComplex.Add(new RecommendationItem { FertilizerName = simpleFertilizers["K"].Name, DoseKgHa = kDeficit / simpleFertilizers["K"].K2O });
            
            var recomendationTextComplex = new StringBuilder();
            double totalAnnualDoseComplex = finalPlanComplex.Sum(item => item.DoseKgHa);
            
            int numberOfParcelsComplex = 1;
            if (totalAnnualDoseComplex > 1500) numberOfParcelsComplex = 4;
            else if (totalAnnualDoseComplex > 1000) numberOfParcelsComplex = 3;
            else if (totalAnnualDoseComplex > 500) numberOfParcelsComplex = 2;
            
            recomendationTextComplex.AppendLine($"O formulado base escolhido foi o **{bestFormula.Name}** por apresentar o melhor balanço geral, minimizando tanto a falta quanto o excesso de nutrientes para a sua necessidade.");
            recomendationTextComplex.AppendLine("\n**Aplicação Anual Total:**");
            foreach (var item in finalPlanComplex.Where(i => i.DoseKgHa > 0))
            {
                recomendationTextComplex.AppendLine($"- **{item.FertilizerName}:** {item.DoseKgHa:F1} kg/ha");
            }
            recomendationTextComplex.AppendLine($"\n**Sugestão de Parcelamento ({numberOfParcelsComplex} aplicações):**");
            recomendationTextComplex.AppendLine($"*Devido à dose total de {totalAnnualDoseComplex:F0} kg/ha, recomendamos dividir a aplicação em {numberOfParcelsComplex} parcelas para otimizar a absorção e reduzir perdas.*");
            foreach (var item in finalPlanComplex.Where(i => i.DoseKgHa > 0))
            {
                recomendationTextComplex.AppendLine($"- **{item.FertilizerName}:** {item.DoseKgHa / numberOfParcelsComplex:F1} kg/ha por aplicação");
            }

            viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel
            {
                Name = "Plano de Formulação NPK",
                Recomendation = recomendationTextComplex.ToString()
            });
        }

        private void LeafRecommendation(FertilizerPlotInputModel inputModel, LeafFertilizerRowData leafData, PlotFertilizerViewModel viewModel)
        {
            foreach (var nutrient in inputModel.Nutrients)
            {
                if (nutrient.Header == NutrientHeader.S.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Zn.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.B.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Mn.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Fe.ToFriendlyString() ||
                    nutrient.Header == NutrientHeader.Cu.ToFriendlyString())
                {
                    var data = leafData.LeafFertilizerColumns
                                    .FirstOrDefault(d => d.Header.ToFriendlyString() == nutrient.Header);
                    if (data == null) continue;

                    if (nutrient.Analysis != "Baixo" && nutrient.Analysis != "Aceitável")
                    {
                        viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel
                        {
                            Name = nutrient.Header,
                            Recomendation = "Não é necessário correção desse nutriente"
                        });
                        continue;
                    }

                    foreach (var product in data.Products)
                    {
                        var recommendation = new ProductRecomendationViewModel
                        {
                            Name = nutrient.Header
                        };

                        if (nutrient.Analysis == "Baixo")
                        {
                            recommendation.Recomendation = product.Solid
                                ? $"Pode-se utilizar {product.MaxConcentration}kg de {product.Name} para uma bomba de 400l de água"
                                : $"Pode-se utilizar {product.MaxConcentration}l de {product.Name} para uma bomba de 400l de água";
                        }
                        else if (nutrient.Analysis == "Aceitável")
                        {
                            recommendation.Recomendation = product.Solid
                                ? $"Pode-se utilizar {product.MinConcentration}kg de {product.Name} para uma bomba de 400l de água"
                                : $"Pode-se utilizar {product.MinConcentration}l de {product.Name} para uma bomba de 400l de água";
                        }

                        viewModel.ProductRecomendations.Add(recommendation);
                    }
                }
            }

            ProductRecomendationViewModel Others = new ProductRecomendationViewModel
            {
                Name = "Macronutrientes",
                Recomendation = "A correção de macronutrientes é feita via solo. Para isso é necessário uma análise de solo para que sejam feitas recomendações"
            };

            viewModel.ProductRecomendations.Add(Others);
        }
    }       
}