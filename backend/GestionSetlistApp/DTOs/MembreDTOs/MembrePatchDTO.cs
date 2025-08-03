using GestionSetlistApp.DTOs.MembreSetlistDTOs;

namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record MembrePatchDTO
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public DateTime? DateNaissance { get; set; }
    }
}