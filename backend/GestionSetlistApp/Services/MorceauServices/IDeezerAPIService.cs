using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs;

namespace GestionSetlistApp.Services.MorceauServices
{
    public interface IDeezerAPIService
    {
        public Task<DeezerAPIEntiteDTO?> RechercherInfosParTitreEtArtiste(string titre, string nomArtiste);

    
    }
}