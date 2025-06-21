using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories
{
    public interface IMorceauxRepository
    {
        public Task<List<Morceau>> GetAllAsync();
        public Task AddMorceauAsync(Morceau morceau);
        public Task DeleteAllAsync();
    }
}