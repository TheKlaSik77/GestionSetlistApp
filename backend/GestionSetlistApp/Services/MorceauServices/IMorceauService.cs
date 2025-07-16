using GestionSetlistApp.DTOs.MorceauDTOs;
using GestionSetlistApp.Models;
namespace GestionSetlistApp.Services.MorceauServices
{
    public interface IMorceauService
    {
        public Task<List<MorceauReadDTO>> GetAllAsync();
        public Task<Morceau> AddMorceauAsync(MorceauCreateDTO morceauDTO);
        public Task AddMorceauxAsync(IEnumerable<MorceauCreateDTO> morceauDTOs);
        public Task<Morceau?> GetMorceauAsync(int morceauId);
        public Task DeleteAllAsync();
        public Task DeleteMorceauAsync(int morceauId);

    }
}