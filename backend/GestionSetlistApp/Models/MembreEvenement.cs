namespace GestionSetlistApp.Models
{
    public class MembreEvenement
    {
        public int EvenementId { get; set; }
        public required Evenement Evenement { get; set; }
        public int MembreId { get; set; }
        public required Membre Membre { get; set; }
    }
}
