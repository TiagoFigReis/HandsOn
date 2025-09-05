using Core.Entities;
using Core.Repositories;
using Infrastructure.Persistence.Context;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CulturesRepository(UsersDbContext context) : ICulturesRepository
    {
        private readonly UsersDbContext _context = context;

        public async Task<IEnumerable<Culture>> GetAllAsync()
        {
            return await _context.Cultures.ToListAsync();
        }

        public async Task<IEnumerable<Culture>> GetAllWithoutNutrientTableAsync()
        {
            var allCultures = await _context.Cultures.ToListAsync();
            var tablelessCultures = new List<Culture>();

            foreach (var culture in allCultures)
            {
                var table = await _context.NutrientTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id);

                if (table == null)
                    tablelessCultures.Add(culture);
            }

            return tablelessCultures;
        }

        public async Task<IEnumerable<Culture>> GetAllWithoutFertilizerTableAsync()
        {
            var allCultures = await _context.Cultures.ToListAsync();
            var tablelessCultures = new List<Culture>();

            foreach (var culture in allCultures)
            {
                var table = await _context.FertilizerTables.FirstOrDefaultAsync(t => t.CultureId == culture.Id);

                if (table == null)
                    tablelessCultures.Add(culture);
            }

            return tablelessCultures;
        }

        public async Task<Culture?> GetByIdAsync(Guid id)
        {
            return await _context.Cultures.FindAsync(id);
        }

        public async Task<Culture?> GetByNameAsync(string name)
        {
            string normalizedName = StringNormalizationService.NormalizeString(name)!;

            return await _context.Cultures.FirstOrDefaultAsync(c => c.NormalizedName == normalizedName);
        }

        public async Task<Culture> AddAsync(Culture culture)
        {
            await _context.Cultures.AddAsync(culture);
            await _context.SaveChangesAsync();
            return culture;
        }

        public async Task<Culture> UpdateAsync(Culture culture)
        {
            _context.Cultures.Update(culture);
            await _context.SaveChangesAsync();
            return culture;
        }

        public async Task<Culture> DeleteAsync(Culture culture)
        {
            _context.Cultures.Remove(culture);
            await _context.SaveChangesAsync();
            return culture;
        }
    }
}