using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Models;
using GestionSetlistApp.Repositories.MembreRepositories;

namespace GestionSetlistApp.Services.MembreServices
{
    public class MembreService(IMembreRepository repository) : IMembreService
    {
        private readonly IMembreRepository _repository = repository;

        public async Task<IEnumerable<MembreReadDTO>> GetAllMembresAsync()
        {
            IEnumerable<Membre> membres = await _repository.GetAllMembresAsync();
            IEnumerable<MembreReadDTO> membresDTO = membres
            .Select(m => new MembreReadDTO
            {
                MembreId = m.MembreId,
                Nom = m.Nom,
                Prenom = m.Prenom,
                Age = m.Age,
                ListeInstruments = m.Instruments.Select(i => new MembreInstrumentReadDTO
                {
                    InstrumentId = i.InstrumentId,
                    Nom = i.Instrument.Nom
                }
            ).ToList()
            }).ToList();
            return membresDTO;
        }

        public async Task<MembreReadDTO> GetMembreAsync(int membreId)
        {
            var membre = await _repository.GetMembreAsync(membreId) ?? throw new KeyNotFoundException();
            return new MembreReadDTO
            {
                MembreId = membre.MembreId,
                Nom = membre.Nom,
                Prenom = membre.Prenom,
                Age = membre.Age,
                ListeInstruments = membre.Instruments.Select(i => new MembreInstrumentReadDTO
                {
                    InstrumentId = i.InstrumentId,
                    Nom = i.Instrument.Nom
                }
                ).ToList()
            };
        }

        public async Task<InstrumentToMembreReadDTO> GetInstrumentToMembreAsync(int membreId, int instrumentId)
        {
            var instrumentToMembre = await _repository.GetInstrumentToMembreAsync(membreId, instrumentId) ?? throw new KeyNotFoundException();
            return new InstrumentToMembreReadDTO
            {
                InstrumentId = instrumentToMembre.InstrumentId,
                MembreId = instrumentToMembre.MembreId
            };
        }

        public async Task<MembreReadDTO> AddMembreAsync(MembreCreateDTO membreDTO)
        {
            if (membreDTO.DateNaissance > DateTime.Today)
            {
                throw new ArgumentException("La date de naissance ne peut pas être dans le futur.");
            }
            var membre = new Membre
            {
                Nom = membreDTO.Nom,
                Prenom = membreDTO.Prenom,
                DateNaissance = membreDTO.DateNaissance
            };

            membre.CalculerAge();
            await _repository.AddMembreAsync(membre);

            return new MembreReadDTO
            {
                MembreId = membre.MembreId,
                Nom = membre.Nom,
                Prenom = membre.Prenom,
                Age = membre.Age,
                ListeInstruments = membre.Instruments.Select(i => new MembreInstrumentReadDTO
                {
                    InstrumentId = i.InstrumentId,
                    Nom = i.Instrument.Nom
                }
                ).ToList()
            };
        }

        public async Task<InstrumentToMembreReadDTO> AddInstrumentToMembreAsync(int membreId, InstrumentToMembreCreateDTO instrumentToMembreCreateDTO)
        {
            var nouveauInstrumentToMembre = new MembreJoueDe
            {
                MembreId = membreId,
                Membre = await _repository.GetMembreAsync(membreId) ?? throw new KeyNotFoundException(),
                InstrumentId = instrumentToMembreCreateDTO.InstrumentId,
                Instrument = await _repository.GetInstrumentAsync(instrumentToMembreCreateDTO.InstrumentId) ?? throw new KeyNotFoundException()
            };
            await _repository.AddInstrumentToMembreAsync(nouveauInstrumentToMembre);

            return new InstrumentToMembreReadDTO
            {
                MembreId = nouveauInstrumentToMembre.MembreId,
                InstrumentId = instrumentToMembreCreateDTO.InstrumentId
            };
        }

        public async Task PatchMembreAsync(int membreId, MembrePatchDTO membrePatchDTO)
        {
            var membre = await _repository.GetMembreAsync(membreId) ?? throw new KeyNotFoundException();
            if (!string.IsNullOrEmpty(membrePatchDTO.Nom))
            {
                membre.Nom = membrePatchDTO.Nom;
            }
            if (!string.IsNullOrEmpty(membrePatchDTO.Prenom))
            {
                membre.Prenom = membrePatchDTO.Prenom;
            }
            if (membrePatchDTO.DateNaissance != null)
            {
                membre.DateNaissance = membrePatchDTO.DateNaissance.Value;
                membre.CalculerAge();
            }
            await _repository.PatchMembreAsync(membre);
        }

        public async Task DeleteMembreAsync(int membreId)
        {
            var membre = await _repository.GetMembreAsync(membreId);
            if (membre == null)
            {
                throw new KeyNotFoundException();
            }
            await _repository.DeleteMembreAsync(membreId);

        }

        public async Task DeleteInstrumentToMembreAsync(int membreId, int instrumentId)
        {
            var instrumentToMembre = await _repository.GetInstrumentToMembreAsync(membreId, instrumentId) ?? throw new KeyNotFoundException();
            await _repository.DeleteInstrumentToMembreAsync(membreId,instrumentId);
        }
    }
}