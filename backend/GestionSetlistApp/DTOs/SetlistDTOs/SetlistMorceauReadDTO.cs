using GestionSetlistApp.Models;

namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record SetlistMorceauReadDTO
    {
        public required int MorceauId { get; set; }
        public required string Titre { get; set; }
        public required string Artiste { get; set; }
        public required int DureeMorceau { get; set; }
        public required int PositionMorceauDansSetlist { get; set; }

        

    }
}