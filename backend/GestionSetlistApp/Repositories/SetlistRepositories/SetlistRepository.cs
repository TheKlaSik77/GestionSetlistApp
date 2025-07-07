using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Repositories.SetlistRepositories
{
    public class SetlistRepository(GestionSetlistDbContext dbContext) : ISetlistRepository
    {
        private readonly GestionSetlistDbContext _dbcontext = dbContext;
        public async Task<IEnumerable<Setlist>> GetAllAsync()
        {
            return await _dbcontext.Setlists
            .Include(ms => ms.MorceauSetlists)
            .Include(e => e.Evenements)
            .Include(m => m.MembreSetlist)
            .ToListAsync();
        }
    }
}