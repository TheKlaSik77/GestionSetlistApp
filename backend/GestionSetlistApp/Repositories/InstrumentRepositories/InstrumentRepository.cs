using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Repositories.InstrumentRepositories
{
    public class InstrumentRepository(GestionSetlistDbContext dbContext) : IInstrumentRepository
    {
        private readonly GestionSetlistDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Instrument>> GetAllInstrumentsAsync()
        {
            return await _dbContext.Instruments.Include(i => i.Membres).ToListAsync();
        }

        public async Task<Instrument?> GetInstrumentAsync(int instrumentId)
        {
            return await _dbContext.Instruments.Include(i => i.Membres).FirstOrDefaultAsync(i => i.InstrumentId == instrumentId);
        }

        public async Task AddInstrumentAsync(Instrument instrument)
        {
            await _dbContext.Instruments.AddAsync(instrument);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteInstrumentAsync(int instrumentId)
        {
            await _dbContext.MembreJoueDe.Where(mjd => mjd.InstrumentId == instrumentId).ExecuteDeleteAsync();
            await _dbContext.Instruments.Where(i => i.InstrumentId == instrumentId).ExecuteDeleteAsync();
        }
    }
}