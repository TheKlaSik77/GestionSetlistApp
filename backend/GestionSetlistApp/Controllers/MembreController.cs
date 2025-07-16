using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Services.MembreServices;
using GestionSetlistApp.DTOs.MembreDTOs;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembreController(IMembreService service) : ControllerBase
    {
        private readonly IMembreService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembreReadDTO>>> GetAllAsync()
        {
            var results = await _service.GetAllAsync();
            return Ok(results);
        }

        [HttpGet("{membreId}")]
        public async Task<ActionResult<MembreReadDTO>> GetMembreAsync(int membreId)
        {
            try
            {
                var membre = await _service.GetMembreAsync(membreId);
                return Ok(membre);
            }
            catch(KeyNotFoundException)
            {
                return NotFound("Membre Invalide");
            }
                
        }

        [HttpPost]
        public async Task<IActionResult> AddMembreAsync([FromBody] MembreCreateDTO membreCreateDTO)
        {
            try
            {
                var nouveauMembre = await _service.AddMembreAsync(membreCreateDTO);
                return CreatedAtAction(nameof(GetMembreAsync), new { membreId = nouveauMembre.MembreId });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _service.DeleteAllAsync();
            return Ok("Tous les membres ont bien été supprimés");
        }


        [HttpDelete("{membreId}")]
        public async Task<ActionResult> DeleteMembreAsync(int membreId)
        {
            try
            {
                await _service.DeleteMembreAsync(membreId);
                return Ok("Membre supprimé");
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre introuvable");
            }
        }
    }
}