
using GestionSetlistApp.DTOs.EvenementDTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestionSetlistApp.Services.EvenementServices
{
    public interface IEvenementService
    {
        public Task<IEnumerable<EvenementReadDTO>> GetAllEvenementsAsync();
        public Task<EvenementReadDTO> GetEvenementAsync(int evenementId);
        public Task<EvenementReadDTO> AddEvenementAsync(EvenementCreateDTO evenementCreateDTO);
        public Task UpdateEvenementAsync(int evenementId, EvenementCreateDTO evenementCreateDTO);
        public Task PatchEvenementAsync(int evenementId, EvenementPatchDTO evenementPatchDTO);
    }
}