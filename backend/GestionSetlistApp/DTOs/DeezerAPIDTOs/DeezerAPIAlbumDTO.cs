using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionSetlistApp.DTOs.DeezerAPIDTOs
{
    public record DeezerAPIAlbumDTO
    {
        [Required]
        [JsonPropertyName("title")]
        public required string Titre { get; set; }
    }
}