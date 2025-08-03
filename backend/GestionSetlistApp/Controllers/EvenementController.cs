using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Services.EvenementServices;
using GestionSetlistApp.DTOs.EvenementDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EvenementController(IEvenementService service) : ControllerBase
    {
        private readonly IEvenementService _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvenementReadDTO>>> GetAllEvenementsAsync()
        {
            var evenements = await _service.GetAllEvenementsAsync();
            return Ok(evenements);
        }
    }

}