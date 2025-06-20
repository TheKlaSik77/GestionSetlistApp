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
    public class MorceauxController(MorceauxService service) : ControllerBase
    {
        private readonly MorceauxService _service = service;

        [HttpGet]

        public ActionResult<string> GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }
        // public async Task<ActionResult<IEnumerable<LivreReadDTO>>> GetAll()
        // {
        //     var livres = await _livreService.GetAllAsync();
        //     return Ok(livres);
        // }
    }
}
