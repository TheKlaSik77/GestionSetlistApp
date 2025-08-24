
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.EvenementRepositories
{
    public interface IEvenementRepository
    {
        public Task<IEnumerable<Evenement>> GetAllEvenementsAsync();
        public Task<Evenement?> GetEvenementAsync(int evenementId);
        public Task AddEvenementAsync(Evenement evenement);
        public Task UpdateEvenementAsync(Evenement evenement);
        public Task DeleteEvenementAsync(int evenementId);
    }  
}