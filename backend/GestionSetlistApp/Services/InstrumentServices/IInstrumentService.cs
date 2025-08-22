using System.Threading.Tasks;
using GestionSetlistApp.DTOs.InstrumentDTOs;

namespace GestionSetlistApp.Services.InstrumentServices
{
    public interface IInstrumentService
    {
        public Task<ICollection<InstrumentReadDTO>> GetAllInstrumentsAsync();
        public Task<InstrumentReadDTO> GetInstrumentAsync(int instrumentId);
        public Task<InstrumentReadDTO> AddInstrumentAsync(InstrumentCreateDTO instrumentCreateDTO);
        public Task DeleteInstrumentAsync(int instrumentId);
    }
}