
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
            .Include(m => m.ListeMembres)
            .ToListAsync();
        }

        public async Task<Evenement?> GetEvenementAsync(int evenementId)
        {
            return await _dbContext.Evenements
            .Include(m => m.ListeMembres)
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
    }
}