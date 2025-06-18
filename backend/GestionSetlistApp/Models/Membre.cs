public class Membre
{
    public int MembreId { get; set; }
    public string Nom { get; set; } = "";
    public string Prenom { get; set; } = "";
    public int Age { get; set; }
    public ICollection<MembreSetlist> MembreSetlist { get; set; } = new List<MembreSetlist>();
    public ICollection<MembreJoueDe> Instruments { get; set; } = new List<MembreJoueDe>();
    public ICollection<MembreEvenement> Evenements { get; set; } = new List<MembreEvenement>();
}