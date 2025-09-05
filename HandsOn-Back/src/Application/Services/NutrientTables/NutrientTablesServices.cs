using System.Security.Claims;
using Application.Exceptions;
using Application.InputModels.NutrientTableInputModels;
using Application.Validators;
using Application.ViewModels;
using Core.Enums;
using Core.Repositories;

namespace Application.Services.NutrientTables
{
    public class NutrientTablesServices
    (
        INutrientTablesRepository nutrientTablesRepository,
        ICulturesRepository culturesRepository,
        IUsersRepository usersRepository
    ) : INutrientTablesServices
    {
        private readonly INutrientTablesRepository _nutrientTablesRepository = nutrientTablesRepository;
        private readonly ICulturesRepository _culturesRepository = culturesRepository;
        private readonly IUsersRepository _usersRepository = usersRepository;

        public async Task<IEnumerable<NutrientTableViewModel>> GetAllAsync(ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId)
                ?? throw new NotFoundException("User not found");

            var cultures = await _culturesRepository.GetAllAsync();

            var nutrientTables = await _nutrientTablesRepository.GetAllAsync(user, cultures);

            return nutrientTables.Select(NutrientTableViewModel.FromEntity);
        }

        public async Task<NutrientTableViewModel> GetByIdAsync(Guid id)
        {
            var nutrientTable = await _nutrientTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Nutrient Table not found");

            return NutrientTableViewModel.FromEntity(nutrientTable);
        }

        public async Task<NutrientTableViewModel> GetByCultureAsync(Guid cultureId, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId)
                ?? throw new NotFoundException("User not found");

            var nutrientTable = await _nutrientTablesRepository.GetByCultureAsync(cultureId, user)
                ?? throw new NotFoundException("Nutrient Table not found");

            return NutrientTableViewModel.FromEntity(nutrientTable);
        }

        public async Task<NutrientTableViewModel> RegisterAsync
        (
            RegisterNutrientTableInputModel inputModel,
            ClaimsPrincipal actionUser
        )
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));
            var user = await _usersRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");

            var culture = await _culturesRepository.GetByIdAsync(inputModel.CultureId)
                ?? throw new NotFoundException("Culture not found");

            var tableExists = await _nutrientTablesRepository.GetByCultureAsync(inputModel.CultureId, user);

            if (tableExists != null && tableExists.UserId == userId)
                throw new ConflictException("Table already exists!");

            var nutrientTable = inputModel.ToEntity();

            nutrientTable.Culture = culture;
            nutrientTable.CultureId = culture.Id;

            nutrientTable.User = user;
            nutrientTable.UserId = userId;

            //Se o usuário for administrador, Standard é true
            if (user.RoleName!.ToRole() == UserRole.Admin)
                nutrientTable.Standard = true;

            await _nutrientTablesRepository.AddAsync(nutrientTable);

            return NutrientTableViewModel.FromEntity(nutrientTable);
        }

        public async Task<NutrientTableViewModel> UpdateAsync
        (
            Guid id,
            UpdateNutrientTableInputModel inputModel,
            ClaimsPrincipal actionUser
        )
        {
            InputModelValidator.Validate(inputModel);

            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));

            var nutrientTable = await _nutrientTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Nutrient Table not found");

            if (nutrientTable.UserId != userId)
                throw new ForbiddenException("This Nutrient Table is inaccessible.");

            nutrientTable.Update(
                division: inputModel.Division,
                tableData: inputModel.ToEntity().GetTableData()
            );

            await _nutrientTablesRepository.UpdateAsync(nutrientTable);

            return NutrientTableViewModel.FromEntity(nutrientTable);
        }

        public async Task<NutrientTableViewModel> DeleteAsync(Guid id, ClaimsPrincipal actionUser)
        {
            var userId = Guid.Parse(actionUser.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new NotFoundException("User not found"));

            var nutrientTable = await _nutrientTablesRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Nutrient Table not found");

            if (nutrientTable.UserId != userId)
                throw new ForbiddenException("This Nutrient Table is inaccessible.");

            await _nutrientTablesRepository.DeleteAsync(nutrientTable);

            return NutrientTableViewModel.FromEntity(nutrientTable);
        }
    }
}