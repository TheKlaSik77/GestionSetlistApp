using System.ComponentModel.DataAnnotations;

namespace GestionSetlistApp.DTOs.MorceauDTOs
{
    public record MorceauCreateDTO
    {
        [Required]
        public required string Titre { get; set; }
        [Required]
        public required string Artiste { get; set; }
        [Required]
        public required string Album { get; set; }
        [Required]
        public required int DureeMorceau { get; set; }
        public string? LienYoutube { get; set; }
    }
} 

