namespace GestionSetlistApp.DTOs.InstrumentDTOs
{
    public record InstrumentMembreReadDTO
    {
        public required int MembreId { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required int Age { get; set; }
    }
}