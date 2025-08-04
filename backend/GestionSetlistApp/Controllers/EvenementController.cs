using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Services.EvenementServices;
using GestionSetlistApp.DTOs.EvenementDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvenementController(IEvenementService service) : ControllerBase
    {
        private readonly IEvenementService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvenementReadDTO>>> GetAllEvenementsAsync()
        {
            var evenements = await _service.GetAllEvenementsAsync();
            return Ok(evenements);
        }

        [HttpGet("{evenementId}", Name = "GetEvenementAsync")]
        public async Task<ActionResult<EvenementReadDTO>> GetEvenementAsync(int evenementId)
        {
            try
            {
                var evenement = await _service.GetEvenementAsync(evenementId);
                return Ok(evenement);

            }
            catch (KeyNotFoundException)
            {
                return NotFound("Evenement Invalide");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddEvenementAsync([FromBody] EvenementCreateDTO evenementCreateDTO)
        {
            var nouvelEvenement = await _service.AddEvenementAsync(evenementCreateDTO);
            return CreatedAtRoute("GetEvenementAsync", new { evenementId = nouvelEvenement.EvenementId }, nouvelEvenement);
        }

        [HttpPut("{evenementId}")]
        public async Task<ActionResult> UpdateEvenementAsync(int evenementId, EvenementCreateDTO evenementCreateDTO)
        {
            try
            {
                await _service.UpdateEvenementAsync(evenementId, evenementCreateDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Evenement Invalide");
            }
        }

        [HttpPatch("{evenementId}")]
        public async Task<ActionResult> PatchEvenementAsync(int evenementId, EvenementPatchDTO evenementPatchDTO)
        {
            try
            {
                await _service.PatchEvenementAsync(evenementId, evenementPatchDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Evenement Invalide");
            }
        }
    }

}