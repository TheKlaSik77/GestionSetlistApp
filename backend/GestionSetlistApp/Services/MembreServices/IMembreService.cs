using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Services.MembreServices
{
    public interface IMembreService
    {
        public Task<IEnumerable<MembreReadDTO>> GetAllMembresAsync();
        public Task<MembreReadDTO> AddMembreAsync(MembreCreateDTO membreDTO);
        public Task<MembreReadDTO> GetMembreAsync(int membreId);
        public Task UpdateMembreAsync(int membreId, MembreCreateDTO membreCreateDTO);
        public Task PatchMembreAsync(int membreId, MembrePatchDTO membrePatchDTO);
        public Task DeleteMembreAsync(int membreId);
        public Task DeleteAllAsync();
    }
}