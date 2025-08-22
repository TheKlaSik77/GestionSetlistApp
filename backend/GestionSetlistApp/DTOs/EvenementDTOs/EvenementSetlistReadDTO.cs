using GestionSetlistApp.DTOs.SetlistDTOs;

namespace GestionSetlistApp.DTOs.EvenementDTOs
{
    public record EvenementSetlistReadDTO
    {
        public required int SetlistId { get; set; }
        public required string NomSetlist { get; set; }
        public required int DureeSetlist { get; set; }
        public required ICollection<SetlistMorceauReadDTO> ListeMorceaux { get; set; }
        public required ICollection<SetlistMembreReadDTO> ListeMembres { get; set; }
    }
}