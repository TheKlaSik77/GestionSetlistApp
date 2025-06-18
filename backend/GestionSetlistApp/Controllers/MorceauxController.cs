using Microsoft.AspNetCore.Mvc;
using GestionSetlistApp.Data;
using GestionSetlistApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionSetlistApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MorceauxController : ControllerBase
    {
        private readonly GestionSetlistDbContext _context;

        public MorceauxController(GestionSetlistDbContext context)
        {
            _context = context;
        }

        // Les méthodes CRUD viendront ici
    }
}
