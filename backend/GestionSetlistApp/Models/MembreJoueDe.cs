public class MembreJoueDe
{
    public int MembreId { get; set; }
    public Membre Membre { get; set; } = null!;
    public int InstrumentId { get; set; }
    public Instrument Instrument { get; set; } = null!;
}