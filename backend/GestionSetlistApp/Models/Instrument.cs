namespace GestionSetlistApp.Models
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public required string Nom { get; set; }
        // Role (Lead / Rythmique etc...)
        public string? Role { get; set; }
        public ICollection<Membre> Membres { get; set; } = [];
    }
}
