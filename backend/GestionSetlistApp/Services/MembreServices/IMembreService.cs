using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Services.MembreServices
{
    public interface IMembreService
    {
        public Task<IEnumerable<MembreReadDTO>> GetAllAsync();
        public Task<MembreReadDTO> AddMembreAsync(MembreCreateDTO membreDTO);
        public Task<MembreReadDTO> GetMembreAsync(int membreId);
        Task DeleteMembreAsync(int membreId);
        Task DeleteAllAsync();
    }
}