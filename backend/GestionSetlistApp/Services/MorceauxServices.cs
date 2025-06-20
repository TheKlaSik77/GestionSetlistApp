using GestionSetlistApp.DTOs.MorceauxDTOs;
using GestionSetlistApp.Repositories;
using GestionSetlistApp.Models;
namespace GestionSetlistApp.Services
{
    public class MorceauxService
    {
        private readonly IMorceauxRepository _morceauxRepository;
        public MorceauxService(IMorceauxRepository morceauxRepository)
        {
            _morceauxRepository = morceauxRepository;
        }

        public List<MorceauxReadDTO> GetAll()
        {
            // On passe la liste de Morceaux récupérés dans la base de données en DTO 
            List<Morceau> morceaux = _morceauxRepository.GetAll();
            List<MorceauxReadDTO> morceauxDTO = morceaux
            .Select(m => new MorceauxReadDTO(m.Titre, m.Artiste))
            .ToList();

            return morceauxDTO;
        }

    }

}
    