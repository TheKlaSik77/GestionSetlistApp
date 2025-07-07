namespace GestionSetlistApp.Models
{
    public class MembreJoueDe
    {
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        public int InstrumentId { get; set; }
        public Instrument? Instrument { get; set; }
    }
}
