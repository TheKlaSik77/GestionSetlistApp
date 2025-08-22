using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.MembreRepositories
{
    public interface IMembreRepository
    {
        public Task<IEnumerable<Membre>> GetAllMembresAsync();
        public Task<Membre?> GetMembreAsync(int membreId);
        public Task<Instrument?> GetInstrumentAsync(int instrumentId);
        public Task<MembreJoueDe?> GetInstrumentToMembreAsync(int membreId, int instrumentId);
        public Task AddMembreAsync(Membre membre);
        public Task AddInstrumentToMembreAsync(MembreJoueDe nouveauInstrumentToMembre);
        public Task PatchMembreAsync(Membre membre);
        public Task DeleteMembreAsync(int membreId);
        public Task DeleteInstrumentToMembreAsync(int membreId, int instrumentId);
    }    
}