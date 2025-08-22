using GestionSetlistApp.DTOs.MorceauSetlistDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.DTOs.MorceauDTOs
{
    public record MorceauReadDTO
    {
        public required int MorceauId { get; set; }
        public required string Titre { get; set; }
        public required string Artiste { get; set; }
        public required string Album { get; set; }
        public required int DureeMorceau { get; set; }
        public required string LienYoutube { get; set; }
        public required ICollection<MorceauSetlistReadDTO> ListeSetlists { get; set; }
    }
}