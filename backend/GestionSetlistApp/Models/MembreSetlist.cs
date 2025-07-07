namespace GestionSetlistApp.Models
{
    public class MembreSetlist
    {
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
        public int SetlistId { get; set; }
        public Setlist? Setlist { get; set; }
    }
}
