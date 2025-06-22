using System.ComponentModel.DataAnnotations;

namespace GestionSetlistApp.DTOs.MorceauxDTOs
{
    public record MorceauxCreateDTO
    {
        [Required]
        public required string Titre { get; set; }
        [Required]
        public required string Artiste { get; set; }
        public string? Album { get; set; }
        public string? LienYoutube { get; set; }
        public int DureeMorceau { get; set; }
    }
}

