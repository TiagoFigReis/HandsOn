using Core.Entities;
using Core.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class FormulationTablesRepository(UsersDbContext context) : IFormulationTablesRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<IEnumerable<FormulationTable>> GetAllAsync(User user, IEnumerable<Culture> cultures)
        {
            var formulationTables = new List<FormulationTable>();

            //Retorna uam tabela para cada cultura. Se houver do usuário, seleciona ela, se não, seleciona a padrão
            foreach (var culture in cultures)
            {
                var formulationTable = await _context.FormulationTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id && t.UserId == user.Id);

                formulationTable ??= await _context.FormulationTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id && t.Standard);

                if (formulationTable != null)
                    formulationTables.Add(formulationTable);
            }

            return formulationTables;
        }

        public async Task<FormulationTable?> GetByIdAsync(Guid id)
        {
            return await _context.FormulationTables.FindAsync(id);
        }

        public async Task<FormulationTable?> GetByCultureAsync(Guid cultureId, User user)
        {
            var formulationTable = await _context.FormulationTables.FirstOrDefaultAsync(t => t.CultureId == cultureId && t.UserId == user.Id);

            //Se não existir uma tabela personalizada do usuário, encontrar a tabela padrão da cultura (Standard == true)
            if (formulationTable == null)
                formulationTable = await _context.FormulationTables.FirstOrDefaultAsync(t => t.Culture.Id == cultureId && t.Standard);

            return formulationTable;
        }

        public async Task<IEnumerable<FormulationTable>> GetAllByCultureAsync(Guid cultureId, User user)
        {
            return await _context.FormulationTables
                .Where(t => t.CultureId == cultureId && (t.UserId == user.Id || t.Standard))
                .ToListAsync();
        }

        public async Task<FormulationTable> AddAsync(FormulationTable formulationTable)
        {
            await _context.FormulationTables.AddAsync(formulationTable);
            await _context.SaveChangesAsync();
            return formulationTable;
        }

        public async Task<FormulationTable> UpdateAsync(FormulationTable formulationTable)
        {
            _context.FormulationTables.Update(formulationTable);
            await _context.SaveChangesAsync();
            return formulationTable;
        }

        public async Task<FormulationTable> DeleteAsync(FormulationTable formulationTable)
        {
            _context.FormulationTables.Remove(formulationTable);
            await _context.SaveChangesAsync();
            return formulationTable;
        }
    }
}