using System.Security.Claims;
using Application.InputModels.FormulationTableInputModels;
using Application.ViewModels;

namespace Application.Services.FormulationTables
{
    public interface IFormulationTablesServices
    {
        Task<IEnumerable<FormulationTableViewModel>> GetAllAsync(ClaimsPrincipal actionUser);
        Task<FormulationTableViewModel> GetByIdAsync(Guid id);
        Task<FormulationTableViewModel> GetByCultureAsync(Guid cultureId, ClaimsPrincipal actionUser);

        Task<FormulationTableViewModel> RegisterAsync(RegisterFormulationTableInputModel inputModel, ClaimsPrincipal actionUser);
        Task<FormulationTableViewModel> UpdateAsync(Guid id, UpdateFormulationTableInputModel inputModel, ClaimsPrincipal actionUser);
        Task<FormulationTableViewModel> DeleteAsync(Guid id, ClaimsPrincipal actionUser);
    }
}