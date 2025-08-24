using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs.MembreSetlistDTOs;
using GestionSetlistApp.Models;
using GestionSetlistApp.Services.SetlistServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class SetlistController(ISetlistService service) : ControllerBase
    {
        private readonly ISetlistService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SetlistReadDTO>>> GetAllSetlistsAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{setlistId}", Name = "GetSetlistAsync")]
        public async Task<ActionResult<SetlistReadDTO>> GetSetlistAsync(int setlistId)
        {
            try
            {
                var setlist = await _service.GetSetlistAsync(setlistId);
                return Ok(setlist);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Setlist Invalide");
            }

        }


        [HttpGet("{setlistId}/morceau/{morceauId}", Name = "GetMorceauToSetlistAsync")]
        public async Task<ActionResult<MorceauToSetlistReadDTO>> GetMorceauToSetlistAsync(int setlistId, int morceauId)
        {
            try
            {
                var morceauToSetlist = await _service.GetMorceauToSetlistAsync(setlistId, morceauId);
                return Ok(morceauToSetlist);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Morceau ou Setlist Invalide");
            }
        }

        [HttpGet("{setlistId}/membre/{membreId}", Name = "GetMembreToSetlistAsync")]
        public async Task<ActionResult<MembreSetlistReadDTO>> GetMembreToSetlistAsync(int setlistId, int membreId)
        {
            try
            {
                var membreSetlist = await _service.GetMembreToSetlistAsync(setlistId, membreId);
                return Ok(membreSetlist);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre ou Setlist Invalide");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSetlistAsync([FromBody] SetlistCreateDTO setlistCreateDTO)
        {
            var nouvelleSetlist = await _service.AddSetlistAsync(setlistCreateDTO);
            return CreatedAtRoute("GetSetlistAsync", new { setlistId = nouvelleSetlist.SetlistId }, nouvelleSetlist);
        }

        [HttpPost("{setlistId}/morceau")]
        public async Task<IActionResult> AddMorceauToSetlist(int setlistId, [FromBody] MorceauToSetlistCreateDTO morceauToSetlistCreateDTO)
        {
            try
            {
                var nouveauSetlistMorceau = await _service.AddMorceauToSetlistAsync(setlistId, morceauToSetlistCreateDTO);
                return CreatedAtRoute("GetMorceauToSetlistAsync", new { setlistId = nouveauSetlistMorceau.SetlistId, morceauId = nouveauSetlistMorceau.MorceauId }, nouveauSetlistMorceau);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Morceau ou Setlist Introuvable");
            }
            

        }

        [HttpPost("{setlistId}/membre")]
        public async Task<IActionResult> AddMembreToSetlistAsync(int setlistId, [FromBody] MembreSetlistCreateDTO membreSetlistCreateDTO)
        {
            try
            {
                var nouveauMembreSetlist = await _service.AddMembreToSetlistAsync(setlistId, membreSetlistCreateDTO);
                return CreatedAtRoute("GetMembreToSetlistAsync" , new {setlistId = nouveauMembreSetlist.SetlistId, membreId = nouveauMembreSetlist.MembreId},nouveauMembreSetlist);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Setlist ou Membre Introuvable");
            }
            
        }


        [HttpDelete("{setlistId}/morceau/{morceauId}")]
        public async Task<ActionResult> DeleteMorceauToSetlistAsync(int setlistId, int morceauId)
        {
            try
            {
                await _service.DeleteMorceauToSetlistAsync(setlistId, morceauId);
                return Ok($"Morceau {morceauId} supprimé de setlist {setlistId}");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Morceau ou Setlist Invalide");
            }
        }

        [HttpDelete("{setlistId}/membre/{membreId}")]
        public async Task<ActionResult> DeleteMembreToSetlistAsync(int setlistId, int membreId)
        {
            try
            {
                await _service.DeleteMembreToSetlistAsync(setlistId, membreId);
                return Ok($"Membre {membreId} supprimé de setlist {setlistId}");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre ou Setlist Invalide");
            }
        }

        [HttpDelete("{setlistId}")]
        public async Task<ActionResult> DeleteSetlistAsync(int setlistId)
        {
            try
            {
                await _service.DeleteSetlistAsync(setlistId);
                return Ok($"Setlist {setlistId} supprimée");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Setlist Invalide");
            }
        }
    }
}