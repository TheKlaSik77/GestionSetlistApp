using System.ComponentModel.DataAnnotations;

namespace GestionSetlistApp.DTOs.MorceauSetlistDTOs
{
    public record MorceauSetlistCreateDTO
    {
        [Required]
        public required int MorceauId { get; set; }
        [Required]
        public required int SetlistId { get; set; }
        public int? Position { get; set; }
    }
}