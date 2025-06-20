namespace GestionSetlistApp.Models
{
    public class MorceauSetlist
    {
        public int MorceauId { get; set; }
        public Morceau Morceau { get; set; } = null!;
        public int SetlistId { get; set; }
        public Setlist Setlist { get; set; } = null!;
        public int Position { get; set; }
    }
}