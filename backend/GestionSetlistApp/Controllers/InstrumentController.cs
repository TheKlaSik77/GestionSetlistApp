using GestionSetlistApp.DTOs.InstrumentDTOs;
using GestionSetlistApp.Services.InstrumentServices;
using Microsoft.AspNetCore.Mvc;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class InstrumentController(IInstrumentService service) : ControllerBase
    {
        private readonly IInstrumentService _service = service;

        [HttpGet]
        public async Task<ActionResult<InstrumentReadDTO>> GetAllInstrumentsAsync()
        {
            var instruments = await _service.GetAllInstrumentsAsync();
            return Ok(instruments);
        }

        [HttpGet("{instrumentId}", Name = "GetInstrumentAsync")]
        public async Task<ActionResult<InstrumentReadDTO>> GetInstrumentAsync(int instrumentId)
        {
            try
            {
                var nouvelInstrument = await _service.GetInstrumentAsync(instrumentId);
                return Ok(nouvelInstrument);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Instrument introuvable");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddInstrumentAsync([FromBody] InstrumentCreateDTO instrumentCreateDTO)
        {
            var nouvelInstrument = await _service.AddInstrumentAsync(instrumentCreateDTO);
            return CreatedAtRoute("GetInstrumentAsync", new { instrumentId = nouvelInstrument.InstrumentId }, nouvelInstrument);
        }

        [HttpDelete("{instrumentId}")]
        public async Task<IActionResult> DeleteInstrumentAsync(int instrumentId)
        {
            try
            {
                await _service.DeleteInstrumentAsync(instrumentId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}