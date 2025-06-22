using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionSetlistApp.DTOs.DeezerAPIDTOs
{
    public record DeezerAPIEntiteDTO
    {
        [Required]
        [JsonPropertyName("title")]
        public required string Titre { get; set; }

        [Required]
        [JsonPropertyName("artist")]
        public required DeezerAPIArtisteDTO Artiste { get; set; }

        [Required]
        [JsonPropertyName("duration")]
        public required int DureeMorceau { get; set; }

        [Required]
        [JsonPropertyName("album")]
        public required DeezerAPIAlbumDTO Album { get; set; }
    }
}