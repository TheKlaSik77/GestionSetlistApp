public class Setlist
{
    public int SetlistId { get; set; }
    public string NomSetlist { get; set; } = "";
    public int DureeSetlist { get; set; }
    public ICollection<Evenement> Evenements { get; set; } = new List<Evenement>();
    public ICollection<MorceauSetlist> Morceaux { get; set; } = new List<MorceauSetlist>();
    public ICollection<MembreSetlist> MembreSetlist { get; set; } = new List<MembreSetlist>();
    
}