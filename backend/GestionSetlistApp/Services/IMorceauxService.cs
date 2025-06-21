using GestionSetlistApp.DTOs.MorceauxDTOs;

namespace GestionSetlistApp.Services
{
    public interface IMorceauxService
    {
        public Task<List<MorceauxReadDTO>> GetAllAsync();
        public Task AddMorceauAsync(MorceauxCreateDTO morceauxDTO);
        public Task DeleteAllAsync();
    }
}