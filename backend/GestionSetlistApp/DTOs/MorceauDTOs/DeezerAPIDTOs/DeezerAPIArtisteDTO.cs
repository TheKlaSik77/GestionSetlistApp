using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs
{
    public record DeezerAPIArtisteDTO
    {
        [Required]
        [JsonPropertyName("name")]
        public required string Nom { get; set; }
    }
}