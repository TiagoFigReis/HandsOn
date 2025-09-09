using System.Security.Claims;
using Application.Exceptions;
using Application.InputModels.FertilizerTableInputModels;
using Application.Validators;
using Application.ViewModels;
using Core.Enums;
using Core.Repositories;

namespace Application.Services.FertilizerTables
{
    public class FertilizerTablesServices
    (
        IFertilizerTablesRepository fertilizerTablesRepository,
        ICulturesRepository culturesRepository,
        IUsersRepository usersRepository
    ) : IFertilizerTablesServices
    {
        private readonly IFertilizerTablesRepository _fertilizerTablesRepository = fertilizerTablesRepository;
        private readonly ICulturesRepository _culturesRepository = culturesRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<IEnumerable<FertilizerTableViewModel>> GetAllAsync(ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var cultures = await _culturesRepository.GetAllAsync();

            var fertilizerTables = await _fertilizerTablesRepository.GetAllAsync(user, cultures);

            return fertilizerTables.Select(FertilizerTableViewModel.FromEntity);
        }

        public async Task<FertilizerTableViewModel> GetByIdAsync(Guid id)
        {
            var fertilizerTable = await _fertilizerTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Fertilizer Table not found");

            return FertilizerTableViewModel.FromEntity(fertilizerTable);
        }

        public async Task<FertilizerTableViewModel> GetByCultureAsync(Guid cultureId, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId)
                ?? throw new NotFoundException("User not found");

            var fertilizerTable = await _fertilizerTablesRepository.GetByCultureAsync(cultureId, user)
                ?? throw new NotFoundException("Fertilizer Table not found");

            return FertilizerTableViewModel.FromEntity(fertilizerTable);
        }

        public async Task<FertilizerTableViewModel> RegisterAsync
        (
            RegisterFertilizerTableInputModel inputModel,
            ClaimsPrincipal actionUser
        )
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var culture = await _culturesRepository.GetByIdAsync(inputModel.CultureId)
                ?? throw new NotFoundException("Culture not found");

            var tableExists = await _fertilizerTablesRepository.GetByCultureAsync(inputModel.CultureId, user);

            if (tableExists != null && tableExists.UserId == userId)
                throw new ConflictException("Table already exists!");

            var fertilizerTable = inputModel.ToEntity();

            fertilizerTable.Culture = culture;
            fertilizerTable.CultureId = culture.Id;

            fertilizerTable.User = user;
            fertilizerTable.UserId = user.Id;

            if (user.RoleName!.ToRole() == UserRole.Admin)
                fertilizerTable.Standard = true;

            await _fertilizerTablesRepository.AddAsync(fertilizerTable);

            return FertilizerTableViewModel.FromEntity(fertilizerTable);
        }

        public async Task<FertilizerTableViewModel> UpdateAsync
        (
            Guid id,
            UpdateFertilizerTableInputModel inputModel,
            ClaimsPrincipal actionUser
        )
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));

            var fertilizerTable = await _fertilizerTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Fertilizer Table not found");

            if (fertilizerTable.UserId != userId)
                throw new ForbiddenException("This Fertilizer Table is inaccessible.");

            fertilizerTable.Update(
                expectedBasesSaturation: inputModel.ExpectedBasesSaturation,
                tableData: inputModel.ToEntity().GetTableData()
            );

            await _fertilizerTablesRepository.UpdateAsync(fertilizerTable);

            return FertilizerTableViewModel.FromEntity(fertilizerTable);
        }

        public async Task<FertilizerTableViewModel> DeleteAsync(Guid id, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));

            var fertilizerTable = await _fertilizerTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Fertilizer Table not found");

            if (fertilizerTable.UserId != userId)
                throw new ForbiddenException("This Fertilizer Table is inaccessible.");

            await _fertilizerTablesRepository.DeleteAsync(fertilizerTable);

            return FertilizerTableViewModel.FromEntity(fertilizerTable);
        }
    }
}