using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.InstrumentRepositories
{
    public interface IInstrumentRepository
    {
        public Task<IEnumerable<Instrument>> GetAllInstrumentsAsync();
        public Task<Instrument?> GetInstrumentAsync(int instrumentId);
        public Task AddInstrumentAsync(Instrument instrument);
        public Task DeleteInstrumentAsync(int instrumentId);
    }
}