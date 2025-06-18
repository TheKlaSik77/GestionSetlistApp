public class MembreSetlist
{
    public int MembreId { get; set; }
    public Membre Membre { get; set; } = null!;
    public int SetlistId { get; set; }
    public Setlist Setlist { get; set; } = null!;
}