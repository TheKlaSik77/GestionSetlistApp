
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using GestionSetlistApp.Repositories.MembreRepositories;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Repositories.EvenementRepositories
{
    public class EvenementRepository(GestionSetlistDbContext dbContext) : IEvenementRepository
    {
        private readonly GestionSetlistDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Evenement>> GetAllEvenementsAsync()
        {
            return await _dbContext.Evenements
            .Include(e => e.Setlist!)
                .ThenInclude(s => s.MorceauSetlists)
                    .ThenInclude(ms => ms.Morceau)
            .Include(e => e.Setlist!)
                .ThenInclude(s => s.MembreSetlist)
                    .ThenInclude(ms => ms.Membre)
            .ToListAsync();
        }

        public async Task<Evenement?> GetEvenementAsync(int evenementId)
        {
            return await _dbContext.Evenements
            .Include(e => e.Setlist!)
                .ThenInclude(s => s.MorceauSetlists)
                    .ThenInclude(ms => ms.Morceau)
            .Include(e => e.Setlist!)
                .ThenInclude(s => s.MembreSetlist)
                    .ThenInclude(ms => ms.Membre)
            .FirstOrDefaultAsync(e => e.EvenementId == evenementId);
        }

        public async Task AddEvenementAsync(Evenement evenement)
        {
            await _dbContext.Evenements.AddAsync(evenement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEvenementAsync(Evenement evenement)
        {
            _dbContext.Evenements.Update(evenement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEvenementAsync(int evenementId)
        {
            await _dbContext.Evenements.Where(e => e.EvenementId == evenementId).ExecuteDeleteAsync();
        }
    }
}