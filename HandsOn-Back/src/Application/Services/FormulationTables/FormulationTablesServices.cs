using System.Security.Claims;
using Application.Exceptions;
using Application.InputModels.FormulationTableInputModels;
using Application.Validators;
using Application.ViewModels;
using Core.Enums;
using Core.Repositories;

namespace Application.Services.FormulationTables
{
    public class FormulationTablesServices
    (
        IFormulationTablesRepository formulationTablesRepository,
        ICulturesRepository culturesRepository,
        IUsersRepository usersRepository
    ) : IFormulationTablesServices
    {
        private readonly IFormulationTablesRepository _formulationTablesRepository = formulationTablesRepository;
        private readonly ICulturesRepository _culturesRepository = culturesRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<IEnumerable<FormulationTableViewModel>> GetAllAsync(ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId)
                ?? throw new NotFoundException("User not found");

            var cultures = await _culturesRepository.GetAllAsync();

            var formulationTables = await _formulationTablesRepository.GetAllAsync(user, cultures);

            return formulationTables.Select(FormulationTableViewModel.FromEntity);
        }

        public async Task<FormulationTableViewModel> GetByIdAsync(Guid id)
        {
            var formulationTable = await _formulationTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Formulation Table not found");

            return FormulationTableViewModel.FromEntity(formulationTable);
        }

        public async Task<FormulationTableViewModel> GetByCultureAsync(Guid cultureId, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId)
                ?? throw new NotFoundException("User not found");

            var formulationTable = await _formulationTablesRepository.GetByCultureAsync(cultureId, user)
                ?? throw new NotFoundException("Formulation Table not found");

            return FormulationTableViewModel.FromEntity(formulationTable);
        }

        public async Task<FormulationTableViewModel> RegisterAsync
        (
            RegisterFormulationTableInputModel inputModel,
            ClaimsPrincipal actionUser
        )
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var culture = await _culturesRepository.GetByIdAsync(inputModel.CultureId)
                ?? throw new NotFoundException("Culture not found");

            var tableExists = await _formulationTablesRepository.GetByCultureAsync(inputModel.CultureId, user);

            if (tableExists != null && tableExists.UserId == userId)
                throw new ConflictException("Table already exists!");

            var formulationTable = inputModel.ToEntity();

            formulationTable.Culture = culture;
            formulationTable.CultureId = culture.Id;

            formulationTable.User = user;
            formulationTable.UserId = userId;

            //Se o usuário for administrador, Standard é true
            if (user.RoleName!.ToRole() == UserRole.Admin)
                formulationTable.Standard = true;

            await _formulationTablesRepository.AddAsync(formulationTable);

            return FormulationTableViewModel.FromEntity(formulationTable);
        }

        public async Task<FormulationTableViewModel> UpdateAsync
        (
            Guid id,
            UpdateFormulationTableInputModel inputModel,
            ClaimsPrincipal actionUser
        )
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));

            var formulationTable = await _formulationTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Formulation Table not found");

            if (formulationTable.UserId != userId)
                throw new ForbiddenException("This Formulation Table is inaccessible.");

            formulationTable.Update(
                tableData: inputModel.ToEntity().GetTableData()
            );

            await _formulationTablesRepository.UpdateAsync(formulationTable);

            return FormulationTableViewModel.FromEntity(formulationTable);
        }

        public async Task<FormulationTableViewModel> DeleteAsync(Guid id, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));

            var formulationTable = await _formulationTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Formulation Table not found");

            if (formulationTable.UserId != userId)
                throw new ForbiddenException("This Formulation Table is inaccessible.");

            await _formulationTablesRepository.DeleteAsync(formulationTable);

            return FormulationTableViewModel.FromEntity(formulationTable);
        }
    }
}