namespace GestionSetlistApp.Models
{
    public class Evenement
    {
        public int EvenementId { get; set; }
        public string Nom { get; set; } = "";
        public DateTime Date { get; set; }
        public string Lieu { get; set; } = "";
        public int SetlistId { get; set; }
        // Propriété de navigation (permet d'accéder directement à la Setlist)
        public Setlist Setlist { get; set; } = null!;
        public ICollection<MembreEvenement> ListeMembres { get; set; } = new List<MembreEvenement>();
        
    }
}
