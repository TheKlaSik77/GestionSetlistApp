namespace GestionSetlistApp.Models
{
    public class MembreSetlist
    {
        public required int MembreId { get; set; }
        public required Membre Membre { get; set; }
        public required int SetlistId { get; set; }
        public required Setlist Setlist { get; set; }
    }
}
