using Core.Entities;

namespace Core.Repositories
{
    public interface ICulturesRepository
    {
        Task<IEnumerable<Culture>> GetAllAsync();
        Task<IEnumerable<Culture>> GetAllWithoutNutrientTableAsync();
        Task<IEnumerable<Culture>> GetAllWithoutFertilizerTableAsync();
        Task<Culture?> GetByIdAsync(Guid id);
        Task<Culture?> GetByNameAsync(string name);

        Task<Culture> AddAsync(Culture culture);
        Task<Culture> UpdateAsync(Culture culture);
        Task<Culture> DeleteAsync(Culture culture);
    }
}