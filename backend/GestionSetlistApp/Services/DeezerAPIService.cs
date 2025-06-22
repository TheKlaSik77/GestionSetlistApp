
using System.Text.Json;
using FuzzySharp;
using GestionSetlistApp.DTOs.DeezerAPIDTOs;

namespace GestionSetlistApp.Services
{
    public class DeezerAPIService(HttpClient httpClient) : IDeezerAPIService
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<DeezerAPIEntiteDTO?> RechercherInfosParTitreEtArtiste(string titre, string nomArtiste)
        {
            string url = $"https://api.deezer.com/search?q={Uri.EscapeDataString($"{titre} {nomArtiste}")}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var searchResult = JsonSerializer.Deserialize<DeezerAPIDTO>(json, options);

            if (searchResult?.Data == null)
                return null;

            return searchResult.Data.Take(5)
            .OrderByDescending(t =>
            {
                int scoreTitre = Fuzz.PartialRatio(t.Titre, titre);
                int scoreArtiste = Fuzz.PartialRatio(t.Artiste.Nom, nomArtiste);
                return (scoreTitre + (scoreArtiste * 2)) / 2;
            })
            .FirstOrDefault();
        }
    }
}