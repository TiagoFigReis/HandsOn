using System.Security.Claims;
using Application.InputModels.DataAnalysisInputModels;
using Application.ViewModels.DataAnalysisViewModels;
using Core.Enums;

namespace Application.Services.DataAnalysis
{
    public interface IDataAnalysisServices
    {
        Task<NutrientAnalysisViewModel> AnalyseNutrients(AnalyseNutrientsInputModel inputModel, ClaimsPrincipal actionUser);

        Task<FertilizerRecomendationViewModel> RecommendFertilizers(RecommendFertilizersInputModel inputModel, ClaimsPrincipal actionUser);
    }
}