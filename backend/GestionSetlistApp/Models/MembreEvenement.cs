public class MembreEvenement
{
    public int EvenementId { get; set; }
    public Evenement Evenement { get; set; } = null!;
    public int MembreId { get; set; }
    public Membre Membre { get; set; } = null!;
}