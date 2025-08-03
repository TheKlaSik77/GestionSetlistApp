
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories.EvenementRepositories
{
    public interface IEvenementRepository
    {
        public Task<IEnumerable<Evenement>> GetAllEvenementsAsync();
    }  
}