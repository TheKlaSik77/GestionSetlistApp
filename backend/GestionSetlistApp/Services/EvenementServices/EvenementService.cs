

using System.Threading.Tasks;
using GestionSetlistApp.DTOs.EvenementDTOs;
using GestionSetlistApp.Models;
using GestionSetlistApp.Repositories.EvenementRepositories;
using GestionSetlistApp.Repositories.MembreRepositories;

namespace GestionSetlistApp.Services.EvenementServices
{
    public class EvenementService(IEvenementRepository repository, IMembreRepository repositoryMembre) : IEvenementService
    {
        private readonly IEvenementRepository _repository = repository;
        private readonly IMembreRepository _repositoryMembre = repositoryMembre;

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

        public async Task<EvenementReadDTO> GetEvenementAsync(int evenementId)
        {
            var evenement = await _repository.GetEvenementAsync(evenementId) ?? throw new KeyNotFoundException();
            return new EvenementReadDTO(
                evenement.EvenementId,
                evenement.Nom,
                evenement.Date,
                evenement.Lieu,
                evenement.SetlistId,
                evenement.ListeMembres.Select(lm => lm.MembreId).ToList()
            );
        }

        public async Task<EvenementReadDTO> AddEvenementAsync(EvenementCreateDTO evenementCreateDTO)
        {
            Evenement nouvelEvenement = new Evenement
            {
                Nom = evenementCreateDTO.Nom,
                Date = evenementCreateDTO.Date,
                Lieu = evenementCreateDTO.Lieu
            };

            await _repository.AddEvenementAsync(nouvelEvenement);
            return new EvenementReadDTO(
                nouvelEvenement.EvenementId,
                nouvelEvenement.Nom,
                nouvelEvenement.Date,
                nouvelEvenement.Lieu,
                nouvelEvenement.SetlistId,
                nouvelEvenement.ListeMembres.Select(ls => ls.MembreId).ToList()
            );
        }
        public async Task UpdateEvenementAsync(int evenementId, EvenementCreateDTO evenementCreateDTO)
        {
            Evenement evenementUpdate = await _repository.GetEvenementAsync(evenementId) ?? throw new KeyNotFoundException();

            evenementUpdate.Nom = evenementCreateDTO.Nom;
            evenementUpdate.Date = evenementCreateDTO.Date;
            evenementUpdate.Lieu = evenementCreateDTO.Lieu;

            await _repository.UpdateEvenementAsync(evenementUpdate);
        }

        public async Task PatchEvenementAsync(int evenementId, EvenementPatchDTO evenementPatchDTO)
        {
            var evenementUpdate = await _repository.GetEvenementAsync(evenementId) ?? throw new KeyNotFoundException();

            if (evenementPatchDTO.Nom != null)
            {
                evenementUpdate.Nom = evenementPatchDTO.Nom;
            }
            if (evenementPatchDTO.Date.HasValue)
            {
                evenementUpdate.Date = evenementPatchDTO.Date.Value;
            }
            if (evenementPatchDTO.Lieu != null)
            {
                evenementUpdate.Lieu = evenementPatchDTO.Lieu;
            }
            if (evenementPatchDTO.SetlistId != null)
            {
                evenementUpdate.SetlistId = evenementPatchDTO.SetlistId;
            }
            if (evenementPatchDTO.ListeMembres != null)
            {
                ICollection<MembreEvenement> listeMembres = [];
                foreach (var membreId in evenementPatchDTO.ListeMembres)
                {
                    var membreEvenement = new MembreEvenement
                    {
                        EvenementId = evenementUpdate.EvenementId,
                        Evenement = evenementUpdate,
                        MembreId = membreId,
                        Membre = await _repositoryMembre.GetMembreAsync(membreId) ?? throw new KeyNotFoundException()
                    };
                    listeMembres.Add(membreEvenement);
                }
                evenementUpdate.ListeMembres = listeMembres;
            }
            await _repository.UpdateEvenementAsync(evenementUpdate);
        }
    }

}