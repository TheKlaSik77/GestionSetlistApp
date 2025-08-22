
using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs;

namespace GestionSetlistApp.DTOs.SetlistDTOs.MembreSetlistDTOs
{
    public record MembreSetlistReadDTO
    {
        public int SetlistId { get; set; }
        public int MembreId { get; set; }
    }
}