namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record InstrumentToMembreReadDTO
    {
        public required int MembreId { get; set; }
        public required int InstrumentId { get; set; }
    }
}