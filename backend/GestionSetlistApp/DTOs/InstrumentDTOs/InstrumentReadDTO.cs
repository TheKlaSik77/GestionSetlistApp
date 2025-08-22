using GestionSetlistApp.DTOs.MembreDTOs;

namespace GestionSetlistApp.DTOs.InstrumentDTOs
{
    public record InstrumentReadDTO
    {
        public required int InstrumentId { get; set; }
        public required string Nom { get; set; }
        public required ICollection<InstrumentMembreReadDTO> Membres { get; set; }
    }
}