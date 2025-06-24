using System.ComponentModel.DataAnnotations;

namespace GestionSetlistApp.DTOs.MorceauxDTOs
{
    public record MorceauxCreateDTO
    {
        [Required]
        public required string Titre { get; set; }
        [Required]
        public required string Artiste { get; set; }
    }
}

