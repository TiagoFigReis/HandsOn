using Core.Entities;

namespace Core.Repositories
{
    public interface IFormulationTablesRepository
    {
        Task<IEnumerable<FormulationTable>> GetAllAsync(User user, IEnumerable<Culture> cultures);
        Task<FormulationTable?> GetByIdAsync(Guid id);
        Task<FormulationTable?> GetByCultureAsync(Guid cultureId, User user);
        Task<IEnumerable<FormulationTable>> GetAllByCultureAsync(Guid cultureId, User user);
        Task<FormulationTable> AddAsync(FormulationTable formulationTable);
        Task<FormulationTable> UpdateAsync(FormulationTable formulationTable);
        Task<FormulationTable> DeleteAsync(FormulationTable formulationTable);
    }
}