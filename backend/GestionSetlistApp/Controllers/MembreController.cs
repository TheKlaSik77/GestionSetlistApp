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
            catch (KeyNotFoundException)
            {
                return NotFound("Membre Invalide");
            }

        }

        [HttpGet("{membreId}/instrument/{instrumentId}", Name = "GetInstrumentToMembreAsync")]
        public async Task<ActionResult<InstrumentToMembreReadDTO>> GetInstrumentToMembreAsync(int membreId, int instrumentId)
        {
            try
            {
                var instrumentToMembre = await _service.GetInstrumentToMembreAsync(membreId, instrumentId);
                return Ok(instrumentToMembre);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre ou Instrument Invalide");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddMembreAsync([FromBody] MembreCreateDTO membreCreateDTO)
        {
            var nouveauMembre = await _service.AddMembreAsync(membreCreateDTO);
            return CreatedAtRoute("GetMembreAsync", new { membreId = nouveauMembre.MembreId }, nouveauMembre);
        }

        [HttpPost("{membreId}/instrument")]
        public async Task<IActionResult> AddInstrumentToMembreAsync(int membreId, [FromBody] InstrumentToMembreCreateDTO instrumentToMembreCreateDTO)
        {
            try
            {
                var nouveauInstrumentToMembre = await _service.AddInstrumentToMembreAsync(membreId, instrumentToMembreCreateDTO);
                return CreatedAtRoute("GetInstrumentToMembreAsync", new { membreId, instrumentToMembreCreateDTO.InstrumentId }, nouveauInstrumentToMembre);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre ou Instrument invalide");
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

        [HttpDelete("{membreId}")]
        public async Task<ActionResult> DeleteMembreAsync(int membreId)
        {
            try
            {
                await _service.DeleteMembreAsync(membreId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre introuvable");
            }
        }

        [HttpDelete("{membreId}/instrument/{instrumentId}")]
        public async Task<IActionResult> DeleteInstrumentToMembreAsync(int membreId, int instrumentId)
        {
            try
            {
                await _service.DeleteInstrumentToMembreAsync(membreId, instrumentId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Membre ou Instrument introuvable");
            }
        }
    }
}