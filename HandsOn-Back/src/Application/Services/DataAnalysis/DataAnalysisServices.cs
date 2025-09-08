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

            float SB = 0, T = 0, organicMatter = 0, V = 0, Vexpected = 60;

            foreach (var nutrient in inputModel.Nutrients)
            {
                if (nutrient.Header == NutrientHeader.SumBases.ToFriendlyString())
                    SB = nutrient.Value;
                else if (nutrient.Header == NutrientHeader.CTCpH7.ToFriendlyString())
                    T = nutrient.Value;
                else if (nutrient.Header == NutrientHeader.OrganicMatter.ToFriendlyString())
                    organicMatter = nutrient.Value;
                else if (nutrient.Header == NutrientHeader.BasesSaturation.ToFriendlyString())
                {
                    V = nutrient.Value;
                }
            }

            foreach (var data in soilData)
            {
                if (expectedProductivity < data.ExpectedProductivity)
                {
                    foreach (var columns in data.SoilFertilizerColumns)
                    {
                        if (columns.Header == NutrientHeader.N)
                        {
                            ProductRecomendationViewModel recomendation = new();

                            float value;

                            if (organicMatter < 3)
                            {
                                value = columns.Value1 * plants / 1000;
                            }
                            else
                            {
                                value = columns.Value2 * plants / 1000;
                            }

                            recomendation.Name = "N";
                            recomendation.Recomendation = $"Pode-se utilizar {value} kg/ha/ano de Nitrogênio(N)";

                            viewModel.ProductRecomendations.Add(recomendation);
                        }
                    }

                    break;

                }
            }

            foreach (var nutrient in inputModel.Nutrients)
            {
                if (nutrient.Header == NutrientHeader.P.ToFriendlyString())
                {
                    foreach (var data in soilData)
                    {
                        if (expectedProductivity < data.ExpectedProductivity)
                        {
                            foreach (var columns in data.SoilFertilizerColumns)
                            {
                                if (columns.Header == NutrientHeader.P)
                                {
                                    ProductRecomendationViewModel recomendation = new();

                                    float value = 0;

                                    if (nutrient.Value <= 10)
                                    {
                                        value = columns.Value1 * plants / 1000;
                                    }
                                    else if (nutrient.Value > 10 && nutrient.Value < 20)
                                    {
                                        value = columns.Value2 * plants / 1000;
                                    }

                                    recomendation.Name = nutrient.Header;
                                    recomendation.Recomendation = value != 0 ? $"Pode-se utilizar {value} kg/ha/abo de Fósforo(P)" : "Não é necessário aplicação desse nutriente";

                                    viewModel.ProductRecomendations.Add(recomendation);
                                }
                            }

                            break;
                        }
                    }
                }
                else if (nutrient.Header == NutrientHeader.K.ToFriendlyString())
                {
                    foreach (var data in soilData)
                    {
                        if (expectedProductivity < data.ExpectedProductivity)
                        {
                            foreach (var columns in data.SoilFertilizerColumns)
                            {
                                if (columns.Header == NutrientHeader.K)
                                {
                                    ProductRecomendationViewModel recomendation = new();

                                    float value = 0;

                                    if (nutrient.Value / T * 100 < 3)
                                    {
                                        value = columns.Value1 * plants / 1000;
                                    }
                                    else if (nutrient.Value / T * 100 >= 3 && nutrient.Value / T * 100 < 5)
                                    {
                                        value = columns.Value2 * plants / 1000;
                                    }
                                    else if (nutrient.Value / T * 100 >= 5 && nutrient.Value / T * 100 < 7)
                                    {
                                        value = columns.Value3 * plants / 1000;
                                    }

                                    recomendation.Name = nutrient.Header;
                                    recomendation.Recomendation = value != 0 ? $"Pode-se utilizar {value} kg/ha/ano de Potássio(K)" : "Não é necessário aplicação desse nutriente";

                                    viewModel.ProductRecomendations.Add(recomendation);
                                }
                            }

                            break;
                        }
                    }
                }
            }

            ProductRecomendationViewModel calagemRecommendation = new();

            calagemRecommendation.Name = "Calagem";

            if (V < Vexpected)
            {
                var calagem = Vexpected / 100 * T - SB;
                calagemRecommendation.Recomendation = $"Pode-se utilizar {calagem}t/ha de calcário";
            }
            else
            {
                calagemRecommendation.Recomendation = "Não é necessário aplicação de calcário";
            }

            ProductRecomendationViewModel Others = new ProductRecomendationViewModel
            {
                Name = "Micronutrientes",
                Recomendation = "A correção de micronutrientes é predominantemente feita via foliar. Para isso é necessário uma análise de folhas para que sejam feitas recomendações"
            };

            viewModel.ProductRecomendations.Add(calagemRecommendation);
            viewModel.ProductRecomendations.Add(Others);
            
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

                    // Caso o nutriente não precise de correção
                    if (nutrient.Analysis != "Baixo" && nutrient.Analysis != "Aceitável")
                    {
                        viewModel.ProductRecomendations.Add(new ProductRecomendationViewModel
                        {
                            Name = nutrient.Header,
                            Recomendation = "Não é necessário correção desse nutriente"
                        });
                        continue; // passa para o próximo nutriente
                    }

                    // Caso o nutriente precise de recomendação (Baixo ou Aceitável)
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