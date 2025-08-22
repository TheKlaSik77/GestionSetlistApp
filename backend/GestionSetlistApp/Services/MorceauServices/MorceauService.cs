using GestionSetlistApp.DTOs.MorceauDTOs;
using GestionSetlistApp.DTOs.MorceauSetlistDTOs;
using GestionSetlistApp.Repositories.MorceauRepositories;
using GestionSetlistApp.Models;
using GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using GestionSetlistApp.Exceptions;

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
            .Select(m => new MorceauReadDTO
            {
                MorceauId = m.MorceauId,
                Titre = m.Titre,
                Artiste = m.Artiste,
                Album = m.Album,
                DureeMorceau = m.DureeMorceau,
                LienYoutube = m.LienYoutube,
                ListeSetlists = m.MorceauSetlists.Select(ms => new MorceauSetlistReadDTO
                {
                    SetlistId = ms.SetlistId,
                    NomSetlist = ms.Setlist.NomSetlist,
                    PositionMorceauDansSetlist = ms.Position
                }).ToList()

            }).ToList();

            return morceauxDTO;
        }

        public async Task<DeezerAPIEntiteDTO> GetInfosAPIDeezer(string titre, string artiste)
        {
            DeezerAPIEntiteDTO deezerAPIEntiteDTO = await _deezerAPIService.RechercherInfosParTitreEtArtiste(titre, artiste) ?? throw new ExternalDataNotFoundException();
            return deezerAPIEntiteDTO;
        }

        public async Task<MorceauReadDTO> GetMorceauAsync(int morceauId)
        {
            var morceau = await _repository.GetMorceauAsync(morceauId) ?? throw new KeyNotFoundException();

            return new MorceauReadDTO
            {
                MorceauId = morceau.MorceauId,
                Titre = morceau.Titre,
                Artiste = morceau.Artiste,
                Album = morceau.Album,
                DureeMorceau = morceau.DureeMorceau,
                LienYoutube = morceau.LienYoutube,
                ListeSetlists = morceau.MorceauSetlists.Select(ms => new MorceauSetlistReadDTO
                {
                    SetlistId = ms.SetlistId,
                    NomSetlist = ms.Setlist.NomSetlist,
                    PositionMorceauDansSetlist = ms.Position
                }).ToList()
            };
        }
        
        public async Task<MorceauReadDTO> AddMorceauAsync(MorceauCreateDTO morceauDTO)
        {

            var morceau = new Morceau
            {
                Titre = morceauDTO.Titre,
                Artiste = morceauDTO.Artiste,
                Album = morceauDTO.Album,
                DureeMorceau = morceauDTO.DureeMorceau,
                LienYoutube = morceauDTO.LienYoutube ?? ""
            };
            await _repository.AddMorceauAsync(morceau);

            return new MorceauReadDTO
            {
                MorceauId = morceau.MorceauId,
                Titre = morceau.Titre,
                Artiste = morceau.Artiste,
                Album = morceau.Album,
                DureeMorceau = morceau.DureeMorceau,
                LienYoutube = morceau.LienYoutube,
                ListeSetlists = morceau.MorceauSetlists.Select(ms => new MorceauSetlistReadDTO
                {
                    SetlistId = ms.SetlistId,
                    NomSetlist = ms.Setlist.NomSetlist,
                    PositionMorceauDansSetlist = ms.Position
                }).ToList()
            };
        }

        public async Task ModifierLienYoutubeAsync(int morceauId, MorceauPatchYoutubeDTO morceauPatchYoutubeDTO)
        {
            var morceau = await _repository.GetMorceauAsync(morceauId) ?? throw new KeyNotFoundException();
            morceau.LienYoutube = morceauPatchYoutubeDTO.LienYoutube;
            await _repository.UpdateMorceauAsync(morceau);
        }

        public async Task DeleteMorceauAsync(int morceauId)
        {
            {
                var morceau = await _repository.GetMorceauAsync(morceauId) ?? throw new KeyNotFoundException();
                await _repository.DeleteMorceauAsync(morceauId);
            }
        }

    }
}
    