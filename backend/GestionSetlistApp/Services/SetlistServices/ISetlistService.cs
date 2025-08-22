using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs.MembreSetlistDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Services.SetlistServices
{
    public interface ISetlistService
    {
        public Task<IEnumerable<SetlistReadDTO>> GetAllAsync();
        public Task<SetlistReadDTO> GetSetlistAsync(int setlistId);
        public Task<MembreSetlistReadDTO> GetMembreToSetlistAsync(int setlistId, int membreId);
        public Task<SetlistReadDTO> AddSetlistAsync(SetlistCreateDTO setlistCreateDTO);
        public Task<MorceauToSetlistReadDTO> AddMorceauToSetlistAsync(int setlistId, MorceauToSetlistCreateDTO morceauToSetlistDTO);
        public Task<MorceauToSetlistReadDTO> GetMorceauToSetlistAsync(int setlistId, int morceauId);
        public Task<MembreSetlistReadDTO> AddMembreToSetlistAsync(int setlistId, MembreSetlistCreateDTO membreSetlistCreateDTO);
        public Task DeleteMorceauToSetlistAsync(int setlistId, int morceauId);
        public Task DeleteMembreToSetlistAsync(int setlistId, int membreId);
        public Task DeleteSetlistAsync(int setlistId);
    }
}