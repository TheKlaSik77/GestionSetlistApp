using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.MorceauRepositories
{
    public interface IMorceauRepository
    {
        public Task<IEnumerable<Morceau>> GetAllAsync();
        public Task<Morceau?> GetMorceauAsync(int morceauId);
        public Task AddMorceauAsync(Morceau morceau);
        public Task AddMorceauxAsync(IEnumerable<Morceau> morceaux);
        public Task UpdateMorceauAsync(Morceau morceau);
        public Task DeleteMorceauAsync(int morceauId);
    }
}