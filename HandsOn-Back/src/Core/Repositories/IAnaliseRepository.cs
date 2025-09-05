using Core.Entities;

namespace Core.Repositories
{
    public interface IAnaliseRepository
    {
        Task<Analise?> GetByIdAsync(Guid Id, Guid userId);

        Task<IEnumerable<Analise>?> GetAllAsync(Guid userId);
        
        Task<Analise> Add(Analise analise);

        Task<Analise> Update(Analise analise);

        Task<Analise> Delete(Analise analise);
    }
}