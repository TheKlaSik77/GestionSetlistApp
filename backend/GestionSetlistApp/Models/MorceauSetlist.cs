namespace GestionSetlistApp.Models
{
    public class MorceauSetlist
    {
        public required int MorceauId { get; set; }
        public required Morceau? Morceau { get; set; }
        public required int SetlistId { get; set; }
        public required Setlist Setlist { get; set; }
        public required int Position { get; set; }
    }
}