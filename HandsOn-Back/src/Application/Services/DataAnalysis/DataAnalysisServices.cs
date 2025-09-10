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
            float calagem = 0;
            string boroRec = "Não é necessário aplicação de Boro (B)";
            string boroValue = "0 kg/ha";

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
                        if (nutrient.Value <= 10)
                            pValue = pCol.Value1 * plants / 1000;
                        else if (nutrient.Value > 10 && nutrient.Value < 20)
                            pValue = pCol.Value2 * plants / 1000;
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
                    }
                }
                else if (header == NutrientHeader.B.ToFriendlyString())
                {
                    var bCol = soilData[0].SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.B);
                    if (bCol != null)
                    {
                        if (nutrient.Analysis == "Baixo")
                        {
                            boroRec = $"Aplicar {bCol.Value1} kg/ha de Boro (B)";
                            boroValue = $"{bCol.Value1} kg/ha";
                        }
                        else if (nutrient.Analysis == "Aceitável")
                        {
                            boroRec = $"Aplicar {bCol.Value2} kg/ha de Boro (B)";
                            boroValue = $"{bCol.Value2} kg/ha";
                        }
                        else if (nutrient.Analysis == "Adequado")
                        {
                            boroRec = $"Aplicar {bCol.Value3} kg/ha de Boro (B)";
                            boroValue = $"{bCol.Value3} kg/ha";
                        }
                    }
                }
            }

            if (V < Vexpected && T > 0)
            {
                calagem = Vexpected / 100 * T - SB;
                if (calagem < 0) calagem = 0;
            }

            GenerateIntegratedRecommendation(nValue, pValue, kValue, calagem, boroRec, boroValue, formulationData, viewModel);
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

        private void GenerateIntegratedRecommendation(float nNeed, float pNeed, float kNeed, float limingNeed, string boronRec, string boroValue, FormulationTableData formulationData, PlotFertilizerViewModel viewModel)
        {
            if (nNeed <= 1 && pNeed <= 1 && kNeed <= 1 && limingNeed <= 0 && boronRec.Contains("Não é necessário"))
            {
                viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel { Name = "Plano de Fertilização", Recomendation = "O solo apresenta níveis adequados de nutrientes e não necessita de correção ou fertilização no momento." });
                return;
            }

            var report = new StringBuilder();

            report.AppendLine("1. Diagnóstico de Necessidades:\n");
            report.AppendLine("Com base na sua análise de solo e produtividade esperada, calculamos as seguintes necessidades anuais por hectare:");
            if (nNeed > 1) report.AppendLine($"- Nitrogênio (N): {nNeed:F0} kg/ha");
            if (pNeed > 1) report.AppendLine($"- Fósforo (P₂O₅): {pNeed:F0} kg/ha");
            if (kNeed > 1) report.AppendLine($"- Potássio (K₂O): {kNeed:F0} kg/ha");
            if (limingNeed > 0) report.AppendLine($"- Calcário: {limingNeed:F2} t/ha");
            if (!boronRec.Contains("Não é necessário")) report.AppendLine($"- Boro (B): {boroValue}\n");

            report.AppendLine("2. Plano de Correção e Fertilização:\n");
            report.AppendLine("Recomendamos o seguinte plano de aplicação anual:\n");
            report.AppendLine("Etapa 1: Correção do Solo:");
            if (limingNeed > 0)
                report.AppendLine($"- Calagem: Aplicar {limingNeed:F2} t/ha de calcário para elevar a Saturação por Bases (V%) ao nível ideal de 70%.");
            else
                report.AppendLine("- Calagem: Não é necessária.");
            report.AppendLine($"- Boro: {boronRec}.\n");
            
            report.AppendLine("Etapa 2: Fertilização NPK:");

            var simpleFertilizers = new Dictionary<string, FertilizerInfo>();
            foreach (var simple in formulationData.BasicFormulationRows.SelectMany(row => row.FormulationColumns))
            {
                if (simple.NAmount == 45) simpleFertilizers["N"] = new FertilizerInfo { Name = "Ureia (45% N)", N = 0.45 };
                if (simple.PAmount == 18) simpleFertilizers["P"] = new FertilizerInfo { Name = "Superfosfato Simples (SSP)", P2O5 = 0.18 };
                if (simple.KAmount == 60) simpleFertilizers["K"] = new FertilizerInfo { Name = "Cloreto de Potássio (KCL)", K2O = 0.60 };
            }

            List<RecommendationItem> finalPlan = new List<RecommendationItem>();
            double totalAnnualDose = 0;
            int numberOfParcels = 1;
            string justification = "";

            int nutrientsNeededCount = 0;
            if (nNeed > 1) nutrientsNeededCount++;
            if (pNeed > 1) nutrientsNeededCount++;
            if (kNeed > 1) nutrientsNeededCount++;

            if (nutrientsNeededCount == 0)
            {
                report.AppendLine("Não é necessária a aplicação de fertilizantes NPK.");
            }
            else if (nutrientsNeededCount == 1)
            {
                justification = "Como a necessidade se concentra em apenas um nutriente, a recomendação é utilizar uma fonte simples.";
                report.AppendLine(justification);

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
                FertilizerInfo? SecondBestFormula = null;
                double bestFormulaDose = 0;
                double SecondBestFormulaDose = 0;
                double bestScore = double.MaxValue;
                double SecondBestScore = double.MaxValue;

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
                                if ((pDeficit > 15) || (kDeficit > 15))
                                {
                                    supplementPenalty = 1000;
                                }

                                double finalScore = (concentrationScore * 3) + deviationScore + supplementPenalty;
                                  
                                if (finalScore < bestScore)
                                {
                                    SecondBestFormula = bestFormula;
                                    SecondBestScore = bestScore;
                                    bestScore = finalScore;
                                    bestFormula = new FertilizerInfo
                                    {
                                        Name = $"NPK {nPercent}-{pPercent}-{kPercent}",
                                        N = nPercent / 100.0,
                                        P2O5 = pPercent / 100.0,
                                        K2O = kPercent / 100.0
                                    };
                                    SecondBestFormulaDose = bestFormulaDose;
                                    bestFormulaDose = doseBasedOnN;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine($"{SecondBestFormula?.Name}, dose = {SecondBestFormulaDose}, score = {SecondBestScore}");

                if (bestFormula != null)
                {
                    justification = $"O formulado recomendado é o {bestFormula.Name}. Esta opção representa o melhor balanço entre um bom ajuste nutricional e a viabilidade comercial (priorizando formulações de menor concentração e de aplicação única). O plano de aplicação é:\n";
                    report.AppendLine(justification);
                    finalPlan.Add(new RecommendationItem { FertilizerName = bestFormula.Name, DoseKgHa = bestFormulaDose });
                }
                else
                {
                    report.AppendLine("Não foi encontrada uma fórmula NPK adequada com base na necessidade de Nitrogênio. Recomenda-se o uso de fontes simples para atender às necessidades de cada nutriente individualmente:");
                    if (nNeed > 1 && simpleFertilizers.ContainsKey("N"))
                        finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["N"].Name, DoseKgHa = nNeed / simpleFertilizers["N"].N });
                    if (pNeed > 1 && simpleFertilizers.ContainsKey("P"))
                        finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["P"].Name, DoseKgHa = pNeed / simpleFertilizers["P"].P2O5 });
                    if (kNeed > 1 && simpleFertilizers.ContainsKey("K"))
                        finalPlan.Add(new RecommendationItem { FertilizerName = simpleFertilizers["K"].Name, DoseKgHa = kNeed / simpleFertilizers["K"].K2O });
                }
            }

            if (finalPlan.Any())
            {
                foreach (var item in finalPlan.Where(i => i.DoseKgHa > 0.1))
                {
                    report.AppendLine($"- {item.FertilizerName}: {item.DoseKgHa:F1} kg/ha");
                }
                report.AppendLine("");
            }

            if (finalPlan.Any())
            {
                report.AppendLine("3. Balanço Final de Nutrientes:\n");
                report.AppendLine("Considerando a aplicação do(s) fertilizante(s) recomendado(s), o balanço final será:");

                var allFertilizers = new List<FertilizerInfo>();
                var bestFormulaInPlan = finalPlan.FirstOrDefault(item => item.FertilizerName.StartsWith("NPK"));
                if(bestFormulaInPlan != null)
                {
                    var parts = bestFormulaInPlan.FertilizerName.Replace("NPK ", "").Split('-');
                    if(parts.Length == 3)
                    {
                        allFertilizers.Add(new FertilizerInfo {
                            Name = bestFormulaInPlan.FertilizerName,
                            N = double.Parse(parts[0]) / 100.0,
                            P2O5 = double.Parse(parts[1]) / 100.0,
                            K2O = double.Parse(parts[2]) / 100.0
                        });
                    }
                }
                allFertilizers.AddRange(simpleFertilizers.Values);

                double totalNApplied = 0;
                double totalPApplied = 0;
                double totalKApplied = 0;
                
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

                Action<string, double, double> addBalanceLine = (nutrientName, applied, needed) => {
                    if (needed <= 1 && applied <= 1) return;
                    double balance = applied - needed;
                    string result;
                    if (Math.Abs(balance) < 1.0) {
                        result = $"Atendido (Balanço: {balance:F1} kg/ha)";
                    } else if (balance > 0) {
                        result = $"Excesso de {balance:F1} kg/ha";
                    } else {
                        result = $"Déficit de {Math.Abs(balance):F1} kg/ha";
                    }
                    report.AppendLine($"- {nutrientName}: Aplicado {applied:F0} kg/ha | Necessidade {needed:F0} kg/ha | Resultado: {result}");
                };

                addBalanceLine("Nitrogênio (N)", totalNApplied, nNeed);
                addBalanceLine("Fósforo (P₂O₅)", totalPApplied, pNeed);
                addBalanceLine("Potássio (K₂O)", totalKApplied, kNeed);
                report.AppendLine("");
            }
            
            totalAnnualDose = finalPlan.Sum(item => item.DoseKgHa);
            if (totalAnnualDose > 1)
            {
                if (totalAnnualDose > 1500) numberOfParcels = 4;
                else if (totalAnnualDose > 1000) numberOfParcels = 3;
                else if (totalAnnualDose > 500) numberOfParcels = 2;

                report.AppendLine("4. Sugestão de Parcelamento\n");
                report.AppendLine($"A dose total de fertilizantes é de {totalAnnualDose:F0} kg/ha. Recomendamos dividir a aplicação em {numberOfParcels} parcelas para otimizar a absorção dos nutrientes.\n");
                report.AppendLine("Aplicação por Parcela:");
                foreach (var item in finalPlan.Where(i => i.DoseKgHa > 0.1))
                {
                    report.AppendLine($"- {item.FertilizerName}: {item.DoseKgHa / numberOfParcels:F1} kg/ha");
                }
                report.AppendLine("");
            }

            report.AppendLine("5. Observações");
            report.AppendLine("- Micronutrientes: A correção de outros micronutrientes (além do Boro) é predominantemente feita via foliar. Para isso, é necessária uma análise de folhas.");

            viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel
            {
                Name = "Plano de Fertilização e Correção de Solo",
                Recomendation = report.ToString()
            });
        }

        private void LeafRecommendation(FertilizerPlotInputModel inputModel, LeafFertilizerRowData leafData, PlotFertilizerViewModel viewModel)
        {
            var correctionsBuilder = new StringBuilder();
            var adequatesBuilder = new StringBuilder();
            int adequateCount = 0;

            int qtd = 1;

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

                    if (data == null || !data.Products.Any()) continue;

                    if (nutrient.Analysis != "Baixo" && nutrient.Analysis != "Aceitável")
                    {
                        if (adequateCount > 0)
                        {
                            adequatesBuilder.Append(", ");
                        }
                        else
                        {
                            adequatesBuilder.Append("   ");
                        }
                        adequatesBuilder.Append($"{nutrient.Header}");
                        adequateCount++;
                        continue;
                    }

                    correctionsBuilder.AppendLine($"{qtd++}. Correção de {nutrient.Header}:");
                    correctionsBuilder.AppendLine($"    Diagnóstico: Nível {nutrient.Analysis}");


                    int productCount = data.Products.Count();

                    if (productCount > 1)
                    {
                        correctionsBuilder.AppendLine("    Para corrigir esta deficiência, sugerimos uma das seguintes opções:");
                    }
                    else
                    {
                        correctionsBuilder.AppendLine("    A recomendação para corrigir esta deficiência é a seguinte:");
                    }

                    foreach (var product in data.Products)
                    {
                        string recommendationText;
                        if (nutrient.Analysis == "Baixo")
                        {
                            recommendationText = product.Solid
                                ? $"    -{product.Name}: {product.MaxConcentration}kg por 400L de água."
                                : $"    -{product.Name}: {product.MaxConcentration}l por 400L de água.";
                        }
                        else
                        {
                            recommendationText = product.Solid
                                ? $"    -{product.Name}: {product.MinConcentration}kg por 400L de água."
                                : $"    -{product.Name}: {product.MinConcentration}l por 400L de água.";
                        }
                        correctionsBuilder.AppendLine(recommendationText);
                    }
                    correctionsBuilder.AppendLine("");
                }
            }

            var finalReport = new StringBuilder();

            if (correctionsBuilder.Length > 0)
            {
                finalReport.Append(correctionsBuilder.ToString());
            }

            if (adequatesBuilder.Length > 0)
            {
                finalReport.AppendLine($"{qtd++}. Nutrientes em Níveis Adequados:\n");
                finalReport.AppendLine("   Os seguintes nutrientes não necessitam de correção foliar no momento:");
                finalReport.AppendLine(adequatesBuilder.ToString());
                finalReport.AppendLine("");
            }

            finalReport.AppendLine($"{qtd}. Observações Gerais");
            finalReport.AppendLine("    -Macronutrientes: A correção de macronutrientes é feita via solo. Para isso é necessário uma análise de solo para que sejam feitas recomendações.");
            finalReport.AppendLine("    -Boas Práticas: Recomenda-se sempre fazer um teste de calda antes da mistura de produtos e realizar a aplicação nas horas mais frescas do dia.");
            
            if (finalReport.Length > 0)
            {
                viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel
                {
                    Name = "Recomendação Foliar",
                    Recomendation = finalReport.ToString()
                });
            }
        }
    }       
}