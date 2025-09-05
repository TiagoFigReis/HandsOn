using System.Security.Claims;
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

                var tableData = fertilizerTable.GetTableData();

                

                if (inputModel.SoilRecomendation)
                {
                    SoilRecommendation(plotInputModel, tableData.SoilFertilizerRows, plotViewModel);
                }
                else
                {
                    LeafRecommendation(plotInputModel, tableData.LeafFertilizerRow, plotViewModel);
                }

                fertilizerViewModel.Plots.Add(plotViewModel);
            }

            return fertilizerViewModel;
        }

        private void SoilRecommendation(FertilizerPlotInputModel inputModel, List<SoilFertilizerRowData> soilData, PlotFertilizerViewModel viewModel)
        {
            var width = inputModel.Spacing.Width;
            var height = inputModel.Spacing.Height;
            var plants = 10000 / (width * height);
            var expectedProductivity = 480 * inputModel.ExpectedProductivity / plants;

            float SB = 0, T = 0, organicMatter = 0, V = 0;
            const float Vexpected = 70;

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
                var nValue = (organicMatter < 3 ? nCol.Value1 : nCol.Value2) * plants / 1000;
                AddRecommendation("N", $"Pode-se utilizar {nValue:F0} kg/ha/ano de Nitrogênio (N)");
            }

            
            foreach (var nutrient in inputModel.Nutrients)
            {
                var header = nutrient.Header;

                
                if (header == NutrientHeader.P.ToFriendlyString())
                {
                    var pCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.P);
                    if (pCol != null)
                    {
                        float value = 0;
                        if (nutrient.Value <= 10)
                            value = pCol.Value1 * plants / 1000;
                        else if (nutrient.Value > 10 && nutrient.Value < 20)
                            value = pCol.Value2 * plants / 1000;

                        if (value > 0)
                            AddRecommendation("P", $"Pode-se utilizar {value:F0} kg/ha/ano de P₂O₅");
                        else
                            AddRecommendation("P", "Não é necessário aplicação desse nutriente");
                    }
                }

                else if (header == NutrientHeader.K.ToFriendlyString())
                {
                    var kCol = selectedSoilData.SoilFertilizerColumns.FirstOrDefault(c => c.Header == NutrientHeader.K);
                    if (kCol != null)
                    {
                        var perc = nutrient.Value / T * 100;
                        float value = 0;

                        if (perc < 3)
                            value = kCol.Value1 * plants / 1000;
                        else if (perc >= 3 && perc < 5)
                            value = kCol.Value2 * plants / 1000;
                        else if (perc >= 5 && perc < 7)
                            value = kCol.Value3 * plants / 1000;

                        if (value > 0)
                            AddRecommendation("K", $"Pode-se utilizar {value:F0} kg/ha/ano de K₂O ");
                        else
                            AddRecommendation("K", "Não é necessário aplicação desse nutriente");
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

                        AddRecommendation("B", rec);
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

            AddRecommendation("Micronutrientes",
                "A correção de micronutrientes é predominantemente feita via foliar. " +
                "Para isso é necessário uma análise de folhas para que sejam feitas recomendações");
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
                Recomendation = "A correção de micronutrientes é feita via solo. Para isso é necessário uma análise de solo para que sejam feitas recomendações"
            };

            viewModel.ProductRecomendations.Add(Others);
        }
    }       
}