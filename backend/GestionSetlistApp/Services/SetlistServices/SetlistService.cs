using System.Linq.Expressions;
using GestionSetlistApp.DTOs.MorceauSetlistDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs.MembreSetlistDTOs;
using GestionSetlistApp.Models;
using GestionSetlistApp.Repositories.MembreRepositories;
using GestionSetlistApp.Repositories.SetlistRepositories;

namespace GestionSetlistApp.Services.SetlistServices
{
    public class SetlistService(ISetlistRepository repository) : ISetlistService
    {
        private readonly ISetlistRepository _repository = repository;
        public async Task<IEnumerable<SetlistReadDTO>> GetAllAsync()
        {
            IEnumerable<Setlist> setlists = await _repository.GetAllAsync();

            IEnumerable<SetlistReadDTO> setlistsDTO = setlists.Select(s => new SetlistReadDTO(
                s.SetlistId,
                s.NomSetlist,
                s.MorceauSetlists.Sum(ms => ms.Morceau.DureeMorceau),
                s.Evenements.Select(e => new SetlistEvenementReadDTO { EvenementId = e.EvenementId, Nom = e.Nom, Date = e.Date, Lieu = e.Lieu }).ToList(),
                s.MorceauSetlists.Select(ms => new SetlistMorceauReadDTO { MorceauId = ms.MorceauId, Titre = ms.Morceau.Titre, Artiste = ms.Morceau.Artiste, DureeMorceau = ms.Morceau.DureeMorceau, PositionMorceauDansSetlist = ms.Position }).ToList(),
                s.MembreSetlist.Select(ms => new SetlistMembreReadDTO
                {
                    MembreId = ms.MembreId,
                    Nom = ms.Membre.Nom,
                    Prenom = ms.Membre.Prenom,
                    Age = ms.Membre.Age,
                    ListeInstruments = ms.Membre.Instruments.Select(i => new SetlistInstrumentReadDTO { InstrumentId = i.InstrumentId, Nom = i.Instrument.Nom }).ToList()
                }
                ).ToList()));

            return setlistsDTO;
        }

        public async Task<SetlistReadDTO> GetSetlistAsync(int setlistId)
        {
            Setlist setlist = await _repository.GetSetlistAsync(setlistId) ?? throw new KeyNotFoundException();

            SetlistReadDTO setlistsDTO = new SetlistReadDTO(
                setlist.SetlistId,
                setlist.NomSetlist,
                setlist.MorceauSetlists.Sum(ms => ms.Morceau.DureeMorceau),
                setlist.Evenements.Select(e => new SetlistEvenementReadDTO { EvenementId = e.EvenementId, Nom = e.Nom, Date = e.Date, Lieu = e.Lieu }).ToList(),
                setlist.MorceauSetlists.Select(ms => new SetlistMorceauReadDTO { MorceauId = ms.MorceauId, Titre = ms.Morceau.Titre, Artiste = ms.Morceau.Artiste, DureeMorceau = ms.Morceau.DureeMorceau, PositionMorceauDansSetlist = ms.Position }).ToList(),
                setlist.MembreSetlist.Select(ms => new SetlistMembreReadDTO
                {
                    MembreId = ms.MembreId,
                    Nom = ms.Membre.Nom,
                    Prenom = ms.Membre.Prenom,
                    Age = ms.Membre.Age,
                    ListeInstruments = ms.Membre.Instruments.Select(i => new SetlistInstrumentReadDTO { InstrumentId = i.InstrumentId, Nom = i.Instrument.Nom }).ToList()
                }
                ).ToList());

            return setlistsDTO;
        }

        public async Task<MembreSetlistReadDTO> GetMembreToSetlistAsync(int setlistId, int membreId)
        {
            var membreSetlist = await _repository.GetMembreToSetlistAsync(setlistId, membreId) ?? throw new KeyNotFoundException();

            return new MembreSetlistReadDTO
            {
                SetlistId = membreSetlist.SetlistId,
                MembreId = membreSetlist.MembreId
            };
        }

        public async Task<MorceauToSetlistReadDTO> GetMorceauToSetlistAsync(int setlistId, int morceauId)
        {
            var morceauToSetlistDTO = await _repository.GetMorceauToSetlistAsync(setlistId, morceauId) ?? throw new KeyNotFoundException();

            return new MorceauToSetlistReadDTO
            {
                MorceauId = morceauToSetlistDTO.MorceauId,
                PositionMorceauDansSetlist = morceauToSetlistDTO.Position
            };
        }

        public async Task<SetlistReadDTO> AddSetlistAsync(SetlistCreateDTO setlistCreateDTO)
        {
            var nouvelleSetlist = new Setlist
            {
                NomSetlist = setlistCreateDTO.Nom,
                DureeSetlist = 0,
                Evenements = [],
                MorceauSetlists = [],
                MembreSetlist = []
            };

            await _repository.AddSetlistAsync(nouvelleSetlist);

            return new SetlistReadDTO
            (
                nouvelleSetlist.SetlistId,
                nouvelleSetlist.NomSetlist,
                nouvelleSetlist.MorceauSetlists.Sum(ms => ms.Morceau.DureeMorceau),
                nouvelleSetlist.Evenements.Select(e => new SetlistEvenementReadDTO { EvenementId = e.EvenementId, Nom = e.Nom, Date = e.Date, Lieu = e.Lieu }).ToList(),
                nouvelleSetlist.MorceauSetlists.Select(ms => new SetlistMorceauReadDTO { MorceauId = ms.MorceauId, Titre = ms.Morceau.Titre, Artiste = ms.Morceau.Artiste, DureeMorceau = ms.Morceau.DureeMorceau, PositionMorceauDansSetlist = ms.Position }).ToList(),
                nouvelleSetlist.MembreSetlist.Select(ms => new SetlistMembreReadDTO
                {
                    MembreId = ms.MembreId,
                    Nom = ms.Membre.Nom,
                    Prenom = ms.Membre.Prenom,
                    Age = ms.Membre.Age,
                    ListeInstruments = ms.Membre.Instruments.Select(i => new SetlistInstrumentReadDTO { InstrumentId = i.InstrumentId, Nom = i.Instrument.Nom }).ToList()
                }
                ).ToList()

            );
        }

        public async Task<MorceauToSetlistReadDTO> AddMorceauToSetlistAsync(int setlistId, MorceauToSetlistCreateDTO morceauToSetlistDTO)
        {
            var setlist = await _repository.GetSetlistAsync(setlistId) ?? throw new KeyNotFoundException();
            var morceau = await _repository.GetMorceauAsync(morceauToSetlistDTO.MorceauId) ?? throw new KeyNotFoundException();

            await _repository.AddMorceauToSetlistAsync(new MorceauSetlist
            {
                SetlistId = setlist.SetlistId,
                Setlist = setlist,
                MorceauId = morceauToSetlistDTO.MorceauId,
                Morceau = morceau,
                Position = morceauToSetlistDTO.PositionMorceauDansSetlist ?? (await _repository.GetMaxPositionSetlistAsync(setlistId)) ?? 1
            });

            return new MorceauToSetlistReadDTO
            {
                MorceauId = morceauToSetlistDTO.MorceauId,
                PositionMorceauDansSetlist = morceauToSetlistDTO.PositionMorceauDansSetlist ?? (await _repository.GetMaxPositionSetlistAsync(setlistId)) ?? 1
            };
        }

        public async Task<MembreSetlistReadDTO> AddMembreToSetlistAsync(int setlistId, MembreSetlistCreateDTO membreSetlistCreateDTO)
        {
            var setlist = await _repository.GetSetlistAsync(setlistId) ?? throw new KeyNotFoundException();
            var membre = await _repository.GetMembreAsync(membreSetlistCreateDTO.MembreId) ?? throw new KeyNotFoundException();

            await _repository.AddMembreToSetlistAsync(new MembreSetlist
            {
                SetlistId = setlistId,
                Setlist = setlist,
                MembreId = membreSetlistCreateDTO.MembreId,
                Membre = membre
            });

            return new MembreSetlistReadDTO
            {
                SetlistId = setlistId,
                MembreId = membreSetlistCreateDTO.MembreId
            };
        }

        public async Task DeleteMorceauToSetlistAsync(int setlistId, int morceauId)
        {
            var morceauToSetlist = await _repository.GetMorceauToSetlistAsync(setlistId, morceauId);
            if (morceauToSetlist == null)
            {
                throw new KeyNotFoundException();
            }
            await _repository.DeleteMorceauToSetlistAsync(setlistId, morceauId);
        }

        public async Task DeleteMembreToSetlistAsync(int setlistId, int membreId)
        {
            var membreToSetlist = await _repository.GetMembreToSetlistAsync(setlistId, membreId) ?? throw new KeyNotFoundException();;
            
            await _repository.DeleteMembreToSetlistAsync(setlistId, membreId);
        }

        public async Task DeleteSetlistAsync(int setlistId)
        {
            var setlist = await _repository.GetSetlistAsync(setlistId) ?? throw new KeyNotFoundException();
            
            await _repository.DeleteSetlistAsync(setlistId);
        }
    }
}