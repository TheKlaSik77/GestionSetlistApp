using System.ComponentModel.DataAnnotations;

namespace GestionSetlistApp.DTOs.MorceauDTOs
{
    public record MorceauCreateDTO
    {
        [Required]
        public required string Titre { get; set; }
        [Required]
        public required string Artiste { get; set; }
    }
}

