using GestionSetlistApp.DTOs.MorceauDTOs;
using GestionSetlistApp.DTOs.MorceauSetlistDTOs;
using GestionSetlistApp.Repositories.MorceauRepositories;
using GestionSetlistApp.Models;
using GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs;

namespace GestionSetlistApp.Services.MorceauServices
{
    public class MorceauService(IMorceauRepository morceauxRepository, IDeezerAPIService deezerAPIService) : IMorceauService
    {
        private readonly IMorceauRepository _repository = morceauxRepository;
        private readonly IDeezerAPIService _deezerAPIService = deezerAPIService;

        public async Task<List<MorceauReadDTO>> GetAllAsync()
        {
            // On passe la liste de Morceaux récupérés dans la base de données en DTO
            IEnumerable<Morceau> morceaux = await _repository.GetAllAsync();

            List<MorceauReadDTO> morceauxDTO = morceaux
            .Select(m => new MorceauReadDTO(m.MorceauId, m.Titre, m.Artiste, m.Album, m.DureeMorceau,
            m.MorceauSetlists
                .Select(ms =>
                    ms.SetlistId
                ).ToList()))
            .ToList();

            return morceauxDTO;
        }

        public async Task<MorceauReadDTO> AddMorceauAsync(MorceauCreateDTO morceauDTO)
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
            return new MorceauReadDTO(
                morceau.MorceauId,
                morceau.Titre,
                morceau.Artiste,
                morceau.Album,
                morceau.DureeMorceau,
                morceau.MorceauSetlists.Select(ms => ms.SetlistId).ToList()
            );
        }

        public async Task AddMorceauxAsync(IEnumerable<MorceauCreateDTO> morceauDTOs)
        {
            List<Morceau> morceaux = [];
            foreach (var morceauDTO in morceauDTOs)
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

        public async Task<Morceau?> GetMorceauAsync(int morceauId)
        {
            return await _repository.GetMorceauAsync(morceauId);
        }

        public async Task DeleteAllAsync()
        {
            await _repository.DeleteAllAsync();
        }
        
        public async Task DeleteMorceauAsync(int morceauId)
        {
            {
                var morceau = await _repository.GetMorceauAsync(morceauId);
                if (morceau is null)
                    throw new KeyNotFoundException();

                await _repository.DeleteMorceauAsync(morceauId);
            }
        }
        
    }
}
    