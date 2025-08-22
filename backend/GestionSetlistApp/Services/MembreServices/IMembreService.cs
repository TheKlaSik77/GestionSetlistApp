using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Services.MembreServices
{
    public interface IMembreService
    {
        public Task<IEnumerable<MembreReadDTO>> GetAllMembresAsync();
        public Task<MembreReadDTO> GetMembreAsync(int membreId);
        public Task<InstrumentToMembreReadDTO> GetInstrumentToMembreAsync(int membreId, int instrumentId);
        public Task<MembreReadDTO> AddMembreAsync(MembreCreateDTO membreDTO);
        public Task<InstrumentToMembreReadDTO> AddInstrumentToMembreAsync(int membreId, InstrumentToMembreCreateDTO instrumentToMembreCreateDTO);
        public Task PatchMembreAsync(int membreId, MembrePatchDTO membrePatchDTO);
        public Task DeleteMembreAsync(int membreId);
        public Task DeleteInstrumentToMembreAsync(int membreId, int instrumentId);
    }
}