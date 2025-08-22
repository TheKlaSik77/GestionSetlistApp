using GestionSetlistApp.DTOs.MorceauDTOs;
using GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs;
using GestionSetlistApp.Models;
namespace GestionSetlistApp.Services.MorceauServices
{
    public interface IMorceauService
    {
        public Task<List<MorceauReadDTO>> GetAllAsync();
        public Task<DeezerAPIEntiteDTO> GetInfosAPIDeezer(string titre, string artiste);
        public Task<MorceauReadDTO> GetMorceauAsync(int morceauId);
        public Task<MorceauReadDTO> AddMorceauAsync(MorceauCreateDTO morceauDTO);
        public Task ModifierLienYoutubeAsync(int morceauId,MorceauPatchYoutubeDTO morceauPatchYoutubeDTO);
        public Task DeleteMorceauAsync(int morceauId);

    }
}