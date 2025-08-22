using GestionSetlistApp.DTOs.InstrumentDTOs;
using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Repositories.InstrumentRepositories;

namespace GestionSetlistApp.Services.InstrumentServices
{
    public class InstrumentService(IInstrumentRepository instrumentRepository) : IInstrumentService
    {
        public readonly IInstrumentRepository _repository = instrumentRepository;

        public async Task<ICollection<InstrumentReadDTO>> GetAllInstrumentsAsync()
        {
            var instruments = await _repository.GetAllInstrumentsAsync();
            return instruments.Select(i => new InstrumentReadDTO
            {
                InstrumentId = i.InstrumentId,
                Nom = i.Nom,
                Membres = i.Membres.Select(m => new InstrumentMembreReadDTO
                {
                    MembreId = m.MembreId,
                    Nom = m.Nom,
                    Prenom = m.Prenom,
                    Age = m.Age
                }).ToList()
            }).ToList();
        }

        public async Task<InstrumentReadDTO> GetInstrumentAsync(int instrumentId)
        {
            var instrument = await _repository.GetInstrumentAsync(instrumentId) ?? throw new KeyNotFoundException();

            return new InstrumentReadDTO
            {
                InstrumentId = instrument.InstrumentId,
                Nom = instrument.Nom,
                Membres = instrument.Membres.Select(m => new InstrumentMembreReadDTO
                {
                    MembreId = m.MembreId,
                    Nom = m.Nom,
                    Prenom = m.Prenom,
                    Age = m.Age
                }).ToList()
            };
        }

        public async Task<InstrumentReadDTO> AddInstrumentAsync(InstrumentCreateDTO instrumentCreateDTO)
        {
            var nouvelInstrument = new Models.Instrument
            {
                Nom = instrumentCreateDTO.Nom,
                Membres = []

            };
            await _repository.AddInstrumentAsync(nouvelInstrument);

            return new InstrumentReadDTO
            {
                InstrumentId = nouvelInstrument.InstrumentId,
                Nom = nouvelInstrument.Nom,
                Membres = nouvelInstrument.Membres.Select(m => new InstrumentMembreReadDTO
                {
                    MembreId = m.MembreId,
                    Nom = m.Nom,
                    Prenom = m.Prenom,
                    Age = m.Age
                }).ToList()
            };
        }

        public async Task DeleteInstrumentAsync(int instrumentId)
        {
            var instrument = await _repository.GetInstrumentAsync(instrumentId) ?? throw new KeyNotFoundException();
            await _repository.DeleteInstrumentAsync(instrumentId);
        }
    }
}