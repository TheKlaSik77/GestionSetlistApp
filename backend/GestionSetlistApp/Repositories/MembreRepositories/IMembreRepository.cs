using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.MembreRepositories
{
    public interface IMembreRepository
    {
        public Task<IEnumerable<Membre>> GetAllMembresAsync();
        public Task AddMembreAsync(Membre membre);
        public Task<Membre?> GetMembreAsync(int membreId);
        public Task UpdateMembreAsync(Membre membre);
        public Task DeleteMembreAsync(int membreId);
        public Task DeleteAllAsync();
    }    
}