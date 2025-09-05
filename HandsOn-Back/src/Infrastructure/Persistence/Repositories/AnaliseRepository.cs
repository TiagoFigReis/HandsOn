using Core.Entities;
using Core.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AnaliseRepository(UsersDbContext context) : IAnaliseRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<Analise?> GetByIdAsync(Guid id, Guid userId)
        {
            return await _context.Analise.FirstOrDefaultAsync(r => r.UserId == userId && r.Id == id);
        }

        public async Task<IEnumerable<Analise>?> GetAllAsync(Guid userId)
        {
            return await _context.Analise.Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<Analise> Add(Analise analise)
        {
            var result = await _context.Analise.AddAsync(analise);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Analise> Update(Analise analise){
            var result = _context.Analise.Update(analise);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Analise> Delete(Analise analise){
            var result = _context.Analise.Remove(analise);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}