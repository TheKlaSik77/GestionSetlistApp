namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record SetlistMembreReadDTO
    {
        public required int MembreId { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required int Age { get; set; }
        public required ICollection<SetlistInstrumentReadDTO> ListeInstruments { get; set; }
    }
}