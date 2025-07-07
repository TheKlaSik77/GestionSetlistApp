using GestionSetlistApp.DTOs.SetlistDTOs;

namespace GestionSetlistApp.Services.SetlistServices
{
    public interface ISetlistService
    {
        public Task<IEnumerable<SetlistReadDTO>> GetAllAsync();
    }
}