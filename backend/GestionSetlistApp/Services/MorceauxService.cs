using GestionSetlistApp.DTOs.MorceauxDTOs;
using GestionSetlistApp.DTOs.MorceauSetlistsDTOs;
using GestionSetlistApp.Repositories;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Services
{
    public class MorceauxService(IMorceauxRepository morceauxRepository) : IMorceauxService
    {
        private readonly IMorceauxRepository _repository = morceauxRepository;

        public async Task<List<MorceauxReadDTO>> GetAllAsync()
        {
            // On passe la liste de Morceaux récupérés dans la base de données en DTO
            List<Morceau> morceaux = await _repository.GetAllAsync();
            List<MorceauxReadDTO> morceauxDTO = morceaux
            .Select(m => new MorceauxReadDTO(m.Titre, m.Artiste, m.Album, m.LienYoutube, m.LienSongsterr, m.DureeMorceau,
            m.MorceauSetlists?
                .Select(ms => new MorceauSetlistsReadDTO(
                    ms.MorceauId,
                    ms.Setlist.NomSetlist,
                    ms.Position)).ToList() ?? new()
                ))
            .ToList();

            return morceauxDTO;
        }

        public async Task AddMorceauAsync(MorceauxCreateDTO morceauxDTO)
        {
            // On récupère un DTO, on en fait un Morceau (model) et on le met dans AddAsync du Repository
            Morceau morceau = new Morceau
            {
                Titre = morceauxDTO.Titre,
                Artiste = morceauxDTO.Artiste,
                Album = morceauxDTO.Album,
                LienYoutube = morceauxDTO.LienYoutube,
                LienSongsterr = morceauxDTO.LienSongsterr,
                DureeMorceau = morceauxDTO.DureeMorceau
            };
            await _repository.AddMorceauAsync(morceau);
        }

        public async Task DeleteAllAsync()
        {
            await _repository.DeleteAllAsync();
        }
    }
}
    