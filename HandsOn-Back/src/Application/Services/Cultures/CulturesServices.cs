using Application.Exceptions;
using Application.Validators;
using Application.ViewModels;
using Core.Repositories;
using Application.InputModels.CultureInputModels;
using Core.Entities;
using Infrastructure.Utils;

namespace Application.Services.Cultures
{
    public class CulturesServices(ICulturesRepository cultureRepository) : ICulturesServices
    {
        private readonly ICulturesRepository _cultureRepository = cultureRepository;

        public async Task<IEnumerable<CultureViewModel>> GetAllAsync()
        {
            var cultures = await _cultureRepository.GetAllAsync();
            return cultures.Select(CultureViewModel.FromEntity);
        }

        public async Task<IEnumerable<CultureViewModel>> GetAllWithoutNutrientTableAsync()
        {
            var cultures = await _cultureRepository.GetAllWithoutNutrientTableAsync();
            return cultures.Select(CultureViewModel.FromEntity);
        }

        public async Task<IEnumerable<CultureViewModel>> GetAllWithoutFertilizerTableAsync()
        {
            var cultures = await _cultureRepository.GetAllWithoutFertilizerTableAsync();
            return cultures.Select(CultureViewModel.FromEntity);
        }

        public async Task<CultureViewModel> GetByIdAsync(Guid id)
        {
            var culture = await _cultureRepository.GetByIdAsync(id) ?? throw new NotFoundException("Culture not found");
            return CultureViewModel.FromEntity(culture);
        }

        public async Task<CultureViewModel> GetByNameAsync(string name)
        {
            var culture = await _cultureRepository.GetByNameAsync(name) ?? throw new NotFoundException("Culture not found");
            return CultureViewModel.FromEntity(culture);
        }

        public async Task<CultureViewModel> RegisterAsync(RegisterCultureInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            if (await _cultureRepository.GetByNameAsync(inputModel.Name!) is not null) throw new ConflictException("Culture exists");

            var culture = new Culture
            {
                Name = inputModel.Name!,
                NormalizedName = StringNormalizationService.NormalizeString(inputModel.Name)!,

                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _cultureRepository.AddAsync(culture);

            return CultureViewModel.FromEntity(culture);
        }

        public async Task<CultureViewModel> UpdateAsync(Guid id, UpdateCultureInputModel inputModel)
        {
            InputModelValidator.Validate(inputModel);

            var culture = await _cultureRepository.GetByIdAsync(id) ?? throw new NotFoundException("Culture not found");

            culture.Update(
                name: inputModel.Name,
                normalizedName: StringNormalizationService.NormalizeString(inputModel.Name)
            );

            await _cultureRepository.UpdateAsync(culture);

            return CultureViewModel.FromEntity(culture);
        }

        public async Task<CultureViewModel> DeleteAsync(Guid id)
        {
            var culture = await _cultureRepository.GetByIdAsync(id) ?? throw new NotFoundException("Culture not found");

            await _cultureRepository.DeleteAsync(culture);

            return CultureViewModel.FromEntity(culture);
        }
    }
}