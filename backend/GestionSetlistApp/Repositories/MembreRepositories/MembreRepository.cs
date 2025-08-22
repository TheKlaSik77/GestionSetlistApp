using Microsoft.EntityFrameworkCore;
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.MembreRepositories
{
    public class MembreRepository(GestionSetlistDbContext dbContext) : IMembreRepository
    {
        private readonly GestionSetlistDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Membre>> GetAllMembresAsync()
        {
            return await _dbContext.Membres
            .Include(i => i.Instruments)
                .ThenInclude(m => m.Instrument)
            .ToListAsync();
        }

        public async Task<Membre?> GetMembreAsync(int membreId)
        {
            return await _dbContext.Membres
            .Include(m => m.Instruments)
                .ThenInclude(m => m.Instrument)
            .FirstOrDefaultAsync(m => m.MembreId == membreId);
        }

        public async Task<Instrument?> GetInstrumentAsync(int instrumentId)
        {
            return await _dbContext.Instruments.FirstOrDefaultAsync(i => i.InstrumentId == instrumentId);
        }

        public async Task<MembreJoueDe?> GetInstrumentToMembreAsync(int membreId, int instrumentId)
        {
            return await _dbContext.MembreJoueDe.FirstOrDefaultAsync(mjd => mjd.InstrumentId == instrumentId && mjd.MembreId == membreId);
        }

        public async Task AddMembreAsync(Membre membre)
        {
            await _dbContext.Membres.AddAsync(membre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddInstrumentToMembreAsync(MembreJoueDe nouveauInstrumentToMembre)
        {
            await _dbContext.MembreJoueDe.AddAsync(nouveauInstrumentToMembre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PatchMembreAsync(Membre membre)
        {
            _dbContext.Membres.Update(membre);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMembreAsync(int membreId)
        {
            var membreASupp = await _dbContext.Membres.FirstAsync(m => m.MembreId == membreId);
            _dbContext.MembreSetlist.RemoveRange(membreASupp.MembreSetlist);
            _dbContext.MembreJoueDe.RemoveRange(membreASupp.Instruments);
            _dbContext.Membres.Remove(membreASupp);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteInstrumentToMembreAsync(int membreId, int instrumentId)
        {
            await _dbContext.MembreJoueDe.Where(mjd => mjd.MembreId == membreId && mjd.InstrumentId == instrumentId).ExecuteDeleteAsync();
        }
    }
}