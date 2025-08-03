using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Services.MembreServices;
using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembreController(IMembreService service) : ControllerBase
    {
        private readonly IMembreService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembreReadDTO>>> GetAllMembresAsync()
        {
            var membres = await _service.GetAllMembresAsync();
            return Ok(membres);
        }

        [HttpGet("{membreId}", Name = "GetMembreAsync")]
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
                //Console.WriteLine($"\n\n\nMembre ajouté avec l'id {nouveauMembre.MembreId}\n\n\n");
                return CreatedAtRoute("GetMembreAsync", new { membreId = nouveauMembre.MembreId }, nouveauMembre);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("batch")]
        public async Task<IActionResult> AddMembresAsync([FromBody] IEnumerable<MembreCreateDTO> membreCreateDTO)
        {
            try
            {
                var membresAjoutes = new List<MembreReadDTO>();
                foreach (var nouveauMembre in membreCreateDTO)
                {
                    var membreAjoute = await _service.AddMembreAsync(nouveauMembre);
                    membresAjoutes.Add(membreAjoute);

                }
                return Created("", membresAjoutes);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{membreId}")]
        public async Task<IActionResult> UpdateMembreAsync(int membreId, [FromBody] MembreCreateDTO membreCreateDTO)
        {
            try
            {
                await _service.UpdateMembreAsync(membreId, membreCreateDTO);
                return NoContent();

            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre Invalide");
            }
        }

        [HttpPatch("{membreId}")]
        public async Task<IActionResult> PatchMembreAsync(int membreId, [FromBody] MembrePatchDTO membrePatchDTO)
        {
            try
            {
                await _service.PatchMembreAsync(membreId, membrePatchDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre Invalide");
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