using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using GestionSetlistApp.Services.MorceauServices;
using GestionSetlistApp.DTOs.MorceauDTOs;
using GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs;
using Microsoft.EntityFrameworkCore;
using GestionSetlistApp.Exceptions;
using GestionSetlistApp.DTOs.MorceauSetlistDTOs;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MorceauController(IMorceauService service) : ControllerBase
    {
        private readonly IMorceauService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MorceauReadDTO>>> GetAllMorceauxAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // Exemple de requête : GET /api/morceau/search?titre=Shape+of+You&artiste=Ed+Sheeran
        [HttpGet("deezersearch")]
        public async Task<ActionResult<DeezerAPIEntiteDTO>> GetInfosAPIDeezer([FromQuery] string titre, [FromQuery] string artiste)
        {
            try 
            {
                var morceau = await _service.GetInfosAPIDeezer(titre, artiste);
                return Ok(morceau);
            }
            catch(ExternalDataNotFoundException)
            {
                return NotFound("Impossible de récupérer les informations du morceau.");
            }
        }


        [HttpGet("{morceauId}", Name = "GetMorceauAsync")]
        public async Task<ActionResult<MorceauReadDTO>> GetMorceauAsync(int morceauId)
        {
            try
            {
                var morceau = await _service.GetMorceauAsync(morceauId);
                return Ok(morceau);
            }
            catch(KeyNotFoundException)
            {
                return NotFound("Morceau Invalide");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMorceauAsync([FromBody] MorceauCreateDTO morceauCreateDTO)
        {          
            var nouveauMorceau = await _service.AddMorceauAsync(morceauCreateDTO);
            return CreatedAtRoute("GetMorceauAsync", new { morceauId = nouveauMorceau.MorceauId }, nouveauMorceau); 
        }

        [HttpPatch("{morceauId}")]
        public async Task<IActionResult> ModifierLienYoutubeAsync(int morceauId, [FromBody] MorceauPatchYoutubeDTO morceauPatchYoutubeDTO)
        {
            try
            {
                await _service.ModifierLienYoutubeAsync(morceauId, morceauPatchYoutubeDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Morceau invalide");
            }
        }

        [HttpDelete("{morceauId}")]
        public async Task<ActionResult> DeleteMorceauAsync(int morceauId)
        {
            try
            {
                await _service.DeleteMorceauAsync(morceauId);
                return Ok("Morceau supprimé");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Morceau introuvable");
            }
        }

       
    }
}
