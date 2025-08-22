using GestionSetlistApp.Models;
using GestionSetlistApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Repositories.MorceauRepositories
{
    public class MorceauRepository(GestionSetlistDbContext dbContext) : IMorceauRepository
    {
        private readonly GestionSetlistDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Morceau>> GetAllAsync()
        {
            return await _dbContext.Morceaux
            .Include(m => m.MorceauSetlists)
            .ToListAsync();
        }

        public async Task AddMorceauAsync(Morceau morceau)
        {
            await _dbContext.Morceaux.AddAsync(morceau);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddMorceauxAsync(IEnumerable<Morceau> morceaux)
        {
            await _dbContext.Morceaux.AddRangeAsync(morceaux);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync()
        {
            var morceauxASupp = _dbContext.Morceaux.ToList();
            _dbContext.Morceaux.RemoveRange(morceauxASupp);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.ExecuteSqlRawAsync("ALTER TABLE morceaux AUTO_INCREMENT = 1;");
        }

        public async Task<Morceau?> GetMorceauAsync(int morceauId)
        {
            // morceau null si non trouvé
            return await _dbContext.Morceaux.Include(m => m.MorceauSetlists)
            .ThenInclude(ms => ms.Setlist).FirstOrDefaultAsync(m => m.MorceauId == morceauId);
        }

        public async Task UpdateMorceauAsync(Morceau morceau)
        {
            _dbContext.Morceaux.Update(morceau);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMorceauAsync(int morceauId)
        {
            var morceau = await _dbContext.Morceaux.FirstOrDefaultAsync(m => m.MorceauId == morceauId) ?? throw new KeyNotFoundException();
            if (morceau.MorceauSetlists.Count != 0)
            {
                _dbContext.MorceauSetlist.RemoveRange(morceau.MorceauSetlists);
            }
            _dbContext.Morceaux.Remove(morceau);
            await _dbContext.SaveChangesAsync();

        }

    }
}