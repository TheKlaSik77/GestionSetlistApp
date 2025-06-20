using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories
{
    public interface IMorceauxRepository
    {
        public List<Morceau> GetAll();
    }
}