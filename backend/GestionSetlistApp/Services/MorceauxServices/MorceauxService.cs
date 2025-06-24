using GestionSetlistApp.DTOs.MorceauxDTOs;
using GestionSetlistApp.DTOs.MorceauSetlistsDTOs;
using GestionSetlistApp.Repositories;
using GestionSetlistApp.Models;
using GestionSetlistApp.DTOs.MorceauxDTOs.DeezerAPIDTOs;

namespace GestionSetlistApp.Services.MorceauxServices
{
    public class MorceauxService(IMorceauxRepository morceauxRepository, IDeezerAPIService deezerAPIService) : IMorceauxService
    {
        private readonly IMorceauxRepository _repository = morceauxRepository;
        private readonly IDeezerAPIService _deezerAPIService = deezerAPIService;

        public async Task<List<MorceauxReadDTO>> GetAllAsync()
        {
            // On passe la liste de Morceaux récupérés dans la base de données en DTO
            List<Morceau> morceaux = await _repository.GetAllAsync();

            List<MorceauxReadDTO> morceauxDTO = morceaux
            .Select(m => new MorceauxReadDTO(m.MorceauId, m.Titre, m.Artiste, m.Album, m.DureeMorceau,
            m.MorceauSetlists?
                .Select(ms => new MorceauSetlistsReadDTO(
                    ms.MorceauId,
                    ms.Setlist.NomSetlist,
                    ms.Position)).ToList() ?? new()
                ))
            .ToList();

            return morceauxDTO;
        }

        public async Task AddMorceauAsync(MorceauxCreateDTO morceauDTO)
        {
            DeezerAPIEntiteDTO? deezerAPIEntiteDTO = await _deezerAPIService.RechercherInfosParTitreEtArtiste(morceauDTO.Titre, morceauDTO.Artiste);

            var morceau = new Morceau
            {
                Titre = morceauDTO.Titre,
                Artiste = morceauDTO.Artiste,
                Album = deezerAPIEntiteDTO?.Album.Titre ?? "Inconnu",
                DureeMorceau = deezerAPIEntiteDTO?.DureeMorceau ?? 0
            };
            await _repository.AddMorceauAsync(morceau);
        }

        public async Task AddMorceauxAsync(IEnumerable<MorceauxCreateDTO> morceauxCreateDTO)
        {
            List<Morceau> morceaux = [];
            foreach (var morceauDTO in morceauxCreateDTO)
            {
                DeezerAPIEntiteDTO? deezerAPIEntiteDTO = await _deezerAPIService.RechercherInfosParTitreEtArtiste(morceauDTO.Titre, morceauDTO.Artiste);

                var morceau = new Morceau
                {
                    Titre = morceauDTO.Titre,
                    Artiste = morceauDTO.Artiste,
                    Album = deezerAPIEntiteDTO?.Album.Titre ?? "Inconnu",
                    DureeMorceau = deezerAPIEntiteDTO?.DureeMorceau ?? 0
                };

                morceaux.Add(morceau);
            }
            await _repository.AddMorceauxAsync(morceaux);

        }

        public async Task<Morceau> GetMorceauAsync(int morceauId)
        {
            return await _repository.GetMorceauAsync(morceauId);
        }

        public async Task DeleteAllAsync()
        {
            await _repository.DeleteAllAsync();
        }
        
        
    }
}
    