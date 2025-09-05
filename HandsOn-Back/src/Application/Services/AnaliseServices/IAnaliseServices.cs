using System.Security.Claims;
using Application.InputModels.InputModelsAnalise;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Services
{
    public interface IAnaliseServices
    {
        Task<AnaliseViewModel?> GetByIdAsync(Guid Id, ClaimsPrincipal actionUser);
        
        Task<IActionResult> GetFiles(Guid Id, ClaimsPrincipal actionUser);

        Task<IEnumerable<AnaliseViewModel>?> GetAllAsync(ClaimsPrincipal actionUser);
        
        Task<AnaliseViewModel> Add(ClaimsPrincipal actionUser, AnaliseInputModel inputModel);

        Task<AnaliseViewModel> Update(ClaimsPrincipal actionUser, Guid Id, AnaliseInputModel inputModel);

        Task<AnaliseViewModel> Delete(ClaimsPrincipal actionUser, Guid Id);
    }
}