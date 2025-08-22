using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.DTOs.MembreEvenementDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.DTOs.EvenementDTOs
{
    public record EvenementReadDTO
    {
        public int EvenementId { get; set; }
        public required string Nom { get; set; }
        public required DateTime Date { get; set; }
        public required string Lieu { get; set; }
        public EvenementSetlistReadDTO? Setlist { get; set; }
    }
}