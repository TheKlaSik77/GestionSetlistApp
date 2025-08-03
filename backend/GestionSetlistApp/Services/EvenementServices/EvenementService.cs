

using System.Threading.Tasks;
using GestionSetlistApp.DTOs.EvenementDTOs;
using GestionSetlistApp.Repositories.EvenementRepositories;

namespace GestionSetlistApp.Services.EvenementServices
{
    public class EvenementService(IEvenementRepository repository) : IEvenementService
    {
        private readonly IEvenementRepository _repository = repository;

        public async Task<IEnumerable<EvenementReadDTO>> GetAllEvenementsAsync()
        {
            var evenements = await _repository.GetAllEvenementsAsync();
            IEnumerable<EvenementReadDTO> evenementsReadDTO = evenements.Select(e => new EvenementReadDTO(
                e.EvenementId,
                e.Nom,
                e.Date,
                e.Lieu,
                e.SetlistId,
                e.ListeMembres.Select(lm => lm.MembreId).ToList()
            )).ToList();
            return evenementsReadDTO;
        }
    }
}