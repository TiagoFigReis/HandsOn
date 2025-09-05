using Core.Entities;
using Core.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class FertilizerTablesRepository(UsersDbContext context) : IFertilizerTablesRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<IEnumerable<FertilizerTable>> GetAllAsync(User user, IEnumerable<Culture> cultures)
        {
            var fertilizerTables = new List<FertilizerTable>();

            //Retorna uam tabela para cada cultura. Se houver do usuário, seleciona ela, se não, seleciona a padrão
            foreach (var culture in cultures)
            {
                var fertilizerTable = await _context.FertilizerTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id && t.UserId == user.Id);

                fertilizerTable ??= await _context.FertilizerTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id && t.Standard);

                if (fertilizerTable != null)
                    fertilizerTables.Add(fertilizerTable);
            }

            return fertilizerTables;
        }

        public async Task<FertilizerTable?> GetByIdAsync(Guid id)
        {
            return await _context.FertilizerTables.FindAsync(id);
        }

        public async Task<FertilizerTable?> GetByCultureAsync(Guid cultureId, User user)
        {
            var fertilizerTable = await _context.FertilizerTables.FirstOrDefaultAsync(t => t.CultureId == cultureId && t.UserId == user.Id);

            //Se não existir uma tabela personalizada do usuário, encontrar a tabela padrão da cultura (Standard == true)
            if (fertilizerTable == null)
                fertilizerTable = await _context.FertilizerTables.FirstOrDefaultAsync(t => t.Culture.Id == cultureId && t.Standard);

            return fertilizerTable;
        }

        public async Task<FertilizerTable> AddAsync(FertilizerTable fertilizerTable)
        {
            await _context.FertilizerTables.AddAsync(fertilizerTable);
            await _context.SaveChangesAsync();
            return fertilizerTable;
        }

        public async Task<FertilizerTable> UpdateAsync(FertilizerTable fertilizerTable)
        {
            _context.FertilizerTables.Update(fertilizerTable);
            await _context.SaveChangesAsync();
            return fertilizerTable;
        }

        public async Task<FertilizerTable> DeleteAsync(FertilizerTable fertilizerTable)
        {
            _context.FertilizerTables.Remove(fertilizerTable);
            await _context.SaveChangesAsync();
            return fertilizerTable;
        }
    }
}