namespace GestionSetlistApp.Models
{
    public class MembreSetlist
    {
        public int MembreId { get; set; }
        public required Membre Membre { get; set; }
        public int SetlistId { get; set; }
        public required Setlist Setlist { get; set; }
    }
}
