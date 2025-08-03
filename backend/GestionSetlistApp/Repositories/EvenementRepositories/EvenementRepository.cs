
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
    }
}