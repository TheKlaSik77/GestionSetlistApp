using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using GestionSetlistApp.Services.MorceauServices;
using GestionSetlistApp.DTOs.MorceauDTOs;
using GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MorceauController(IMorceauService service) : ControllerBase
    {
        private readonly IMorceauService _service = service;

        [HttpGet]

        public async Task<ActionResult<IEnumerable<MorceauReadDTO>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
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

        [HttpPost("batch")]
        public async Task<IActionResult> AddMorceauxAsync([FromBody] IEnumerable<MorceauCreateDTO> morceauCreateDTO)
        {
            await _service.AddMorceauxAsync(morceauCreateDTO);
            return Ok("Morceaux Ajoutés");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _service.DeleteAllAsync();
            return Ok("Tous les morceaux ont bien été supprimés");
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
