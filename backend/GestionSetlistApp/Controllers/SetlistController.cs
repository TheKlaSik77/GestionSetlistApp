using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.Services.SetlistServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("/setlist")]
    public class SetlistController(ISetlistService service) : ControllerBase
    {
        private readonly ISetlistService _service = service;

        [HttpGet]

        public async Task<ActionResult<IEnumerable<SetlistReadDTO>>> GetAllAsync()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // [HttpGet("{setlistId}")]

        // public async Task<ActionResult<SetlistReadDTO>> GetSetlistAsync(int setlistId)
        // {
        //     var result = await _service.GetSetlistAsync(setlistId);
        //     return result != null ? Ok(result) : NotFound("Id invalide");
        // }
    }
}