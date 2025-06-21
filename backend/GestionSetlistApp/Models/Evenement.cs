namespace GestionSetlistApp.Models
{
    public class Evenement
    {
        public int EvenementId { get; set; }
        public required string Nom { get; set; }
        public required DateTime Date { get; set; }
        public required string Lieu { get; set; }
        public int? SetlistId { get; set; }
        // Propriété de navigation (permet d'accéder directement à la Setlist)
        public Setlist? Setlist { get; set; }
        public ICollection<MembreEvenement>? ListeMembres { get; set; } = new List<MembreEvenement>();
        
    }
}
