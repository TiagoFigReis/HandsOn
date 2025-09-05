using Core.Entities;
using Core.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class NutrientTablesRepository(UsersDbContext context) : INutrientTablesRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<IEnumerable<NutrientTable>> GetAllAsync(User user, IEnumerable<Culture> cultures)
        {
            var nutrientTables = new List<NutrientTable>();

            //Retorna uam tabela para cada cultura. Se houver do usuário, seleciona ela, se não, seleciona a padrão
            foreach (var culture in cultures)
            {
                var nutrientTable = await _context.NutrientTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id && t.UserId == user.Id);

                nutrientTable ??= await _context.NutrientTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id && t.Standard);

                if (nutrientTable != null)
                    nutrientTables.Add(nutrientTable);
            }

            return nutrientTables;
        }

        public async Task<NutrientTable?> GetByIdAsync(Guid id)
        {
            return await _context.NutrientTables.FindAsync(id);
        }

        public async Task<NutrientTable?> GetByCultureAsync(Guid cultureId, User user)
        {
            var nutrientTable = await _context.NutrientTables.FirstOrDefaultAsync(t => t.CultureId == cultureId  && t.UserId == user.Id);

            //Se não existir uma tabela personalizada do usuário, encontrar a tabela padrão da cultura (Standard == true)
            if (nutrientTable == null)
                nutrientTable = await _context.NutrientTables.FirstOrDefaultAsync(t => t.Culture.Id == cultureId && t.Standard);

            return nutrientTable;
        }

        public async Task<IEnumerable<NutrientTable>> GetAllByCultureAsync(Guid cultureId, User user)
        {
            return await _context.NutrientTables
                .Where(t => t.CultureId == cultureId && (t.UserId == user.Id || t.Standard))
                .ToListAsync();
        }

        public async Task<NutrientTable> AddAsync(NutrientTable nutrientTable)
        {
            await _context.NutrientTables.AddAsync(nutrientTable);
            await _context.SaveChangesAsync();
            return nutrientTable;
        }

        public async Task<NutrientTable> UpdateAsync(NutrientTable nutrientTable)
        {
            _context.NutrientTables.Update(nutrientTable);
            await _context.SaveChangesAsync();
            return nutrientTable;
        }

        public async Task<NutrientTable> DeleteAsync(NutrientTable nutrientTable)
        {
            _context.NutrientTables.Remove(nutrientTable);
            await _context.SaveChangesAsync();
            return nutrientTable;
        }
    }
}