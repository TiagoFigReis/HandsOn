using System.Security.Claims;
using Application.InputModels.NutrientTableInputModels;
using Application.ViewModels;

namespace Application.Services.NutrientTables
{
    public interface INutrientTablesServices
    {
        Task<IEnumerable<NutrientTableViewModel>> GetAllAsync(ClaimsPrincipal actionUser);
        Task<NutrientTableViewModel> GetByIdAsync(Guid id);
        Task<NutrientTableViewModel> GetByCultureAsync(Guid cultureId, ClaimsPrincipal actionUser);

        Task<NutrientTableViewModel> RegisterAsync(RegisterNutrientTableInputModel inputModel, ClaimsPrincipal actionUser);
        Task<NutrientTableViewModel> UpdateAsync(Guid id, UpdateNutrientTableInputModel inputModel, ClaimsPrincipal actionUser);
        Task<NutrientTableViewModel> DeleteAsync(Guid id, ClaimsPrincipal actionUser);
    }
}