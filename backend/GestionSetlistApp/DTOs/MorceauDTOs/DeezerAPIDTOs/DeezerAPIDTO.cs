using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionSetlistApp.DTOs.MorceauDTOs.DeezerAPIDTOs
{
    public record DeezerAPIDTO
    {
        [Required]
        [JsonPropertyName("data")]
        public required List<DeezerAPIEntiteDTO> Data { get; set; } = [];
    }
}