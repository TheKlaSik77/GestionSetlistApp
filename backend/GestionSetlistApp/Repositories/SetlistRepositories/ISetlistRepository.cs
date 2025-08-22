using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.SetlistRepositories
{
    public interface ISetlistRepository
    {
        public Task<IEnumerable<Setlist>> GetAllAsync();
        public Task<Setlist?> GetSetlistAsync(int setlistId);
        public Task AddSetlistAsync(Setlist setlist);
        public Task<Morceau?> GetMorceauAsync(int MorceauId);
        public Task<MembreSetlist?> GetMembreToSetlistAsync(int setlistId, int membreId);
        public Task<MorceauSetlist?> GetMorceauToSetlistAsync(int setlistId, int morceauId);
        public Task<int?> GetMaxPositionSetlistAsync(int setlistId);
        public Task<Membre?> GetMembreAsync(int membreId);
        public Task AddMorceauToSetlistAsync(MorceauSetlist morceauSetlist);
        public Task AddMembreToSetlistAsync(MembreSetlist membreSetlist);
        public Task DeleteMorceauToSetlistAsync(int setlistId, int morceauId);
        public Task DeleteMembreToSetlistAsync(int setlistId, int membreId);
        public Task DeleteSetlistAsync(int setlistId);
        
    }
}