

using System.Threading.Tasks;
using GestionSetlistApp.DTOs.EvenementDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs;
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
            IEnumerable<EvenementReadDTO> evenementsReadDTO = evenements.Select(e => new EvenementReadDTO
            {
                EvenementId = e.EvenementId,
                Nom = e.Nom,
                Date = e.Date,
                Lieu = e.Lieu,
                Setlist = e.Setlist == null ? null : new EvenementSetlistReadDTO
                {
                    SetlistId = e.Setlist.SetlistId,
                    NomSetlist = e.Setlist.NomSetlist,
                    DureeSetlist = e.Setlist.DureeSetlist,
                    ListeMorceaux = e.Setlist.MorceauSetlists.Select(ms => new SetlistMorceauReadDTO
                    {
                        MorceauId = ms.MorceauId,
                        Titre = ms.Morceau.Titre,
                        Artiste = ms.Morceau.Artiste,
                        DureeMorceau = ms.Morceau.DureeMorceau,
                        PositionMorceauDansSetlist = ms.Position
                    }).ToList(),

                    ListeMembres = e.Setlist.MembreSetlist.Select(ms => new SetlistMembreReadDTO
                    {
                        MembreId = ms.MembreId,
                        Nom = ms.Membre.Nom,
                        Prenom = ms.Membre.Prenom,
                        Age = ms.Membre.Age,
                        ListeInstruments = ms.Membre.Instruments.Select(i => new SetlistInstrumentReadDTO
                        {
                            InstrumentId = i.InstrumentId,
                            Nom = i.Instrument.Nom
                        }).ToList()
                    }).ToList()
                }
            }).ToList();
            return evenementsReadDTO;
        }

        public async Task<EvenementReadDTO> GetEvenementAsync(int evenementId)
        {
            var evenement = await _repository.GetEvenementAsync(evenementId) ?? throw new KeyNotFoundException();
            return new EvenementReadDTO
            {
                EvenementId = evenement.EvenementId,
                Nom = evenement.Nom,
                Date = evenement.Date,
                Lieu = evenement.Lieu,
                Setlist = evenement.Setlist == null ? null : new EvenementSetlistReadDTO
                {
                    SetlistId = evenement.Setlist.SetlistId,
                    NomSetlist = evenement.Setlist.NomSetlist,
                    DureeSetlist = evenement.Setlist.DureeSetlist,
                    ListeMorceaux = evenement.Setlist.MorceauSetlists.Select(ms => new SetlistMorceauReadDTO
                    {
                        MorceauId = ms.MorceauId,
                        Titre = ms.Morceau.Titre,
                        Artiste = ms.Morceau.Artiste,
                        DureeMorceau = ms.Morceau.DureeMorceau,
                        PositionMorceauDansSetlist = ms.Position
                    }).ToList(),

                    ListeMembres = evenement.Setlist.MembreSetlist.Select(ms => new SetlistMembreReadDTO
                    {
                        MembreId = ms.MembreId,
                        Nom = ms.Membre.Nom,
                        Prenom = ms.Membre.Prenom,
                        Age = ms.Membre.Age,
                        ListeInstruments = ms.Membre.Instruments.Select(i => new SetlistInstrumentReadDTO
                        {
                            InstrumentId = i.InstrumentId,
                            Nom = i.Instrument.Nom
                        }).ToList()
                    }).ToList()
                }
            };
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
            return new EvenementReadDTO
            {
                EvenementId = nouvelEvenement.EvenementId,
                Nom = nouvelEvenement.Nom,
                Date = nouvelEvenement.Date,
                Lieu = nouvelEvenement.Lieu,
                Setlist = nouvelEvenement.Setlist == null ? null : new EvenementSetlistReadDTO
                {
                    SetlistId = nouvelEvenement.Setlist.SetlistId,
                    NomSetlist = nouvelEvenement.Setlist.NomSetlist,
                    DureeSetlist = nouvelEvenement.Setlist.DureeSetlist,
                    ListeMorceaux = nouvelEvenement.Setlist.MorceauSetlists.Select(ms => new SetlistMorceauReadDTO
                    {
                        MorceauId = ms.MorceauId,
                        Titre = ms.Morceau.Titre,
                        Artiste = ms.Morceau.Artiste,
                        DureeMorceau = ms.Morceau.DureeMorceau,
                        PositionMorceauDansSetlist = ms.Position
                    }).ToList(),

                    ListeMembres = nouvelEvenement.Setlist.MembreSetlist.Select(ms => new SetlistMembreReadDTO
                    {
                        MembreId = ms.MembreId,
                        Nom = ms.Membre.Nom,
                        Prenom = ms.Membre.Prenom,
                        Age = ms.Membre.Age,
                        ListeInstruments = ms.Membre.Instruments.Select(i => new SetlistInstrumentReadDTO
                        {
                            InstrumentId = i.InstrumentId,
                            Nom = i.Instrument.Nom
                        }).ToList()
                    }).ToList()
                }
            };
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
            
            await _repository.UpdateEvenementAsync(evenementUpdate);
        }
    }

}