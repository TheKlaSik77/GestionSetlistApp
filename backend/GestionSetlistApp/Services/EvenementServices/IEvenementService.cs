
using GestionSetlistApp.DTOs.EvenementDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionSetlistApp.Services.EvenementServices
{
    public interface IEvenementService
    {
        public Task<IEnumerable<EvenementReadDTO>> GetAllEvenementsAsync();
    }
}