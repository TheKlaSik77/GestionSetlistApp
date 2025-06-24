using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using GestionSetlistApp.DTOs.MorceauxDTOs.DeezerAPIDTOs;

namespace GestionSetlistApp.Services.MorceauxServices
{
    public interface IDeezerAPIService
    {
        public Task<DeezerAPIEntiteDTO?> RechercherInfosParTitreEtArtiste(string titre, string nomArtiste);

    
    }
}