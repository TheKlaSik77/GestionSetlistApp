using GestionSetlistApp.DTOs.MembreSetlistDTOs;

namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record MembreCreateDTO
    {
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required DateTime DateNaissance { get; set; }

    }
}