using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.MorceauRepositories
{
    public interface IMorceauRepository
    {
        public Task<IEnumerable<Morceau>> GetAllAsync();
        public Task AddMorceauAsync(Morceau morceau);
        public Task AddMorceauxAsync(IEnumerable<Morceau> morceaux);
        public Task<Morceau> GetMorceauAsync(int morceauId);
        public Task DeleteAllAsync();
        public Task DeleteMorceauAsync(Morceau morceau);
    }
}