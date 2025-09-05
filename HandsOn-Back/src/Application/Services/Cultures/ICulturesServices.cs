using System.Security.Claims;
using Application.InputModels.CultureInputModels;
using Application.ViewModels;

namespace Application.Services.Cultures
{
    public interface ICulturesServices
    {
        Task<IEnumerable<CultureViewModel>> GetAllAsync();
        Task<IEnumerable<CultureViewModel>> GetAllWithoutNutrientTableAsync();
        Task<IEnumerable<CultureViewModel>> GetAllWithoutFertilizerTableAsync();
        Task<CultureViewModel> GetByIdAsync(Guid id);
        Task<CultureViewModel> GetByNameAsync(string name);

        Task<CultureViewModel> RegisterAsync(RegisterCultureInputModel inputModel);
        Task<CultureViewModel> UpdateAsync(Guid id, UpdateCultureInputModel inputModel);
        Task<CultureViewModel> DeleteAsync(Guid id);
    }
}