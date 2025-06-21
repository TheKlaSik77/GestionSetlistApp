using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using GestionSetlistApp.Services;
using GestionSetlistApp.DTOs.MorceauxDTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("/morceaux")]
    // /morceaux
    public class MorceauxController(IMorceauxService service) : ControllerBase
    {
        private readonly IMorceauxService _service = service;

        [HttpGet]

        public async Task<ActionResult<IEnumerable<MorceauxReadDTO>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost("addOne")]
        public async Task<IActionResult> AddMorceauAsync([FromBody] MorceauxCreateDTO morceauxCreateDTO)
        {

            await _service.AddMorceauAsync(morceauxCreateDTO);
            return Ok("Morceau Ajouté");
        }

        // [HttpPost("addMany")]
        // public async Task<IActionResult> AddMorceauxAsync([FromBody] IEnumerable<MorceauxCreateDTO> morceauxCreateDTO)
        // {

        //     await _service.AddMorceauxSync(morceauxCreateDTO);
        //     return Ok("Morceaux Ajoutés");
        // }

        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _service.DeleteAllAsync();
            return Ok("Tous les morceaux ont bien été supprimés");
        }
    }
}
