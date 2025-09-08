using Core.Entities;

namespace Core.Repositories
{
    public interface IFertilizerTablesRepository
    {
        Task<IEnumerable<FertilizerTable>> GetAllAsync(User user, IEnumerable<Culture> cultures);
        Task<FertilizerTable?> GetByIdAsync(Guid id);
        Task<FertilizerTable?> GetByCultureAsync(Guid cultureId, User user);
        Task<FertilizerTable> AddAsync(FertilizerTable fertilizerTable);
        Task<FertilizerTable> UpdateAsync(FertilizerTable fertilizerTable);
        Task<FertilizerTable> DeleteAsync(FertilizerTable fertilizerTable);
    }
}