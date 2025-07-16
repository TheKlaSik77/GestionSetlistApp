using Microsoft.EntityFrameworkCore;
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.MembreRepositories
{
    public class MembreRepository(GestionSetlistDbContext dbContext) : IMembreRepository
    {
        private readonly GestionSetlistDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Membre>> GetAllAsync()
        {
            return await _dbContext.Membres
            .Include(s => s.MembreSetlist)
            .Include(i => i.Instruments)
            .Include(e => e.MembreEvenements)
            .ToListAsync();
        }
        public async Task AddMembreAsync(Membre membre)
        {
            await _dbContext.Membres.AddAsync(membre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Membre?> GetMembreAsync(int membreId)
        {
            return await _dbContext.Membres.Include(m => m.MembreEvenements).Include(m => m.Instruments).Include(m => m.MembreSetlist).FirstOrDefaultAsync(m => m.MembreId == membreId); 
        }
        public async Task DeleteAllAsync()
        {
            var membresASupp = _dbContext.Membres.ToList();
            foreach (var m in membresASupp)
            {
                _dbContext.MembreSetlist.RemoveRange(m.MembreSetlist);
                _dbContext.MembreEvenement.RemoveRange(m.MembreEvenements);
                _dbContext.MembreJoueDe.RemoveRange(m.Instruments);
            }
            _dbContext.Membres.RemoveRange(membresASupp);
            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.ExecuteSqlRawAsync("ALTER TABLE membres AUTO_INCREMENT = 1;");
            
        }
        public async Task DeleteMembreAsync(int membreId)
        {
            var membreASupp = await _dbContext.Membres.FirstAsync(m => m.MembreId == membreId);
            _dbContext.Membres.Remove(membreASupp);
            await _dbContext.SaveChangesAsync();

        }
    }
}