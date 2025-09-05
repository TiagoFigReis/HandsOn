using System.Security.Claims;
using Application.InputModels.FertilizerTableInputModels;
using Application.ViewModels;

namespace Application.Services.FertilizerTables
{
    public interface IFertilizerTablesServices
    {
        Task<IEnumerable<FertilizerTableViewModel>> GetAllAsync(ClaimsPrincipal actionUser);
        Task<FertilizerTableViewModel> GetByIdAsync(Guid id);
        Task<FertilizerTableViewModel> GetByCultureAsync(Guid cultureId, ClaimsPrincipal actionUser);

        Task<FertilizerTableViewModel> RegisterAsync(RegisterFertilizerTableInputModel inputModel, ClaimsPrincipal actionUser);
        Task<FertilizerTableViewModel> UpdateAsync(Guid id, UpdateFertilizerTableInputModel inputModel, ClaimsPrincipal actionUser);
        Task<FertilizerTableViewModel> DeleteAsync(Guid id, ClaimsPrincipal actionUser);
    }
}