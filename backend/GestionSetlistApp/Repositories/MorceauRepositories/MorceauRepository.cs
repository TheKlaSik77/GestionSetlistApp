using GestionSetlistApp.Models;
using GestionSetlistApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Repositories.MorceauRepositories
{
    public class MorceauRepository(GestionSetlistDbContext dbContext) : IMorceauRepository
    {
        // Ici on implémente le dbContext
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

        public async Task<Morceau> GetMorceauAsync(int morceauId)
        {
            // morceau null si non trouvé
            var morceau = await _dbContext.Morceaux.Include(m => m.MorceauSetlists)
            .ThenInclude(ms => ms.Setlist).FirstAsync(m => m.MorceauId == morceauId);

            return morceau;
        }

        public async Task DeleteMorceauAsync(Morceau morceau)
        {
            if (morceau.MorceauSetlists.Any())
            {
                _dbContext.MorceauSetlist.RemoveRange(morceau.MorceauSetlists);
            }
            _dbContext.Morceaux.Remove(morceau);
            await _dbContext.SaveChangesAsync();

        }
    }
}