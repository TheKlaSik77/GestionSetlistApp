using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using GestionSetlistApp.Services;
using GestionSetlistApp.DTOs.MorceauxDTOs;
using GestionSetlistApp.DTOs.DeezerAPIDTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("/morceaux")]
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
        public async Task<IActionResult> AddMorceauAsync([FromBody] MorceauxCreateDTO morceauCreateDTO)
        {

            await _service.AddMorceauAsync(morceauCreateDTO);
            return Ok("Morceau Ajouté");
        }

        [HttpPost("addMany")]
        public async Task<IActionResult> AddMorceauxAsync([FromBody] IEnumerable<MorceauxCreateDTO> morceauxCreateDTO)
        {
            await _service.AddMorceauxAsync(morceauxCreateDTO);
            return Ok("Morceaux Ajoutés");
        }


        [HttpGet("{morceauId}")]
        public async Task<ActionResult<Morceau>> GetMorceauAsync(int morceauId)
        {
            var morceau = await _service.GetMorceauAsync(morceauId);
            return morceau != null ? Ok(morceau) : NotFound("Id Invalide");
        }

        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllAsync()
        {
            await _service.DeleteAllAsync();
            return Ok("Tous les morceaux ont bien été supprimés");
        }





        // [HttpGet("testDeezerApi")]
        // public async Task<ActionResult<DeezerAPIEntiteDTO?>> RechercheTitreArtiste()
        // {

        //     return await _deezerAPIService.RechercherInfosParTitreEtArtiste("Que tu reviennes", "Patrick Fiori");
        // }
    }
}
