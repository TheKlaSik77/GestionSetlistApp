using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.SetlistRepositories
{
    public interface ISetlistRepository
    {
        public Task<IEnumerable<Setlist>> GetAllAsync();
    }
}