namespace GestionSetlistApp.Models
{
    public class Evenement
    {
        public int EvenementId { get; set; }
        public required string Nom { get; set; }
        public required DateTime Date { get; set; }
        public required string Lieu { get; set; }
        public int? SetlistId { get; set; }
        public Setlist? Setlist { get; set; }        
    }
}
