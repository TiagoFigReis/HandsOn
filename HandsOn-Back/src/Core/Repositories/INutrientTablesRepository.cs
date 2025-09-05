using Core.Entities;

namespace Core.Repositories
{
    public interface INutrientTablesRepository
    {
        Task<IEnumerable<NutrientTable>> GetAllAsync(User user, IEnumerable<Culture> cultures);
        Task<NutrientTable?> GetByIdAsync(Guid id);
        Task<NutrientTable?> GetByCultureAsync(Guid cultureId, User user);
        Task<IEnumerable<NutrientTable>> GetAllByCultureAsync(Guid cultureId, User user);
        Task<NutrientTable> AddAsync(NutrientTable nutrientTable);
        Task<NutrientTable> UpdateAsync(NutrientTable nutrientTable);
        Task<NutrientTable> DeleteAsync(NutrientTable nutrientTable);
    }
}