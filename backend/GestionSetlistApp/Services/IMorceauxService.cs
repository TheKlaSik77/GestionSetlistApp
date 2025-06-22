using GestionSetlistApp.DTOs.MorceauxDTOs;
using GestionSetlistApp.Models;
namespace GestionSetlistApp.Services
{
    public interface IMorceauxService
    {
        public Task<List<MorceauxReadDTO>> GetAllAsync();
        public Task AddMorceauAsync(MorceauxCreateDTO morceauDTO);
        public Task AddMorceauxAsync(IEnumerable<MorceauxCreateDTO> morceauxDTO);
        public Task<Morceau> GetMorceauAsync(int morceauId);
        public Task DeleteAllAsync();
    }
}