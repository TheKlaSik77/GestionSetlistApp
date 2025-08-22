namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record SetlistInstrumentReadDTO
    {
        public required int InstrumentId { get; set; }
        public required string Nom { get; set; }

    }
}