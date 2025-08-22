namespace GestionSetlistApp.Models
{
    public class MembreJoueDe
    {
        public required int MembreId { get; set; }
        public required Membre Membre { get; set; }
        public required int InstrumentId { get; set; }
        public required Instrument Instrument { get; set; }
    }
}
