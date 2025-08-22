namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record MembreInstrumentReadDTO
    {
        public required int InstrumentId { get; set; }
        public required string Nom { get; set; }
    }
}