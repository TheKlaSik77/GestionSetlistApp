namespace GestionSetlistApp.Models
{
    public class MembreEvenement
    {
        public int EvenementId { get; set; }
        public Evenement? Evenement { get; set; }
        public int MembreId { get; set; }
        public Membre? Membre { get; set; }
    }
}
