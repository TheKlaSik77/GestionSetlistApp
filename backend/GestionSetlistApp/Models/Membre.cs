namespace GestionSetlistApp.Models
{
    public class Membre
    {
        public int MembreId { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; } = "";
        public required int Age { get; set; }
        public ICollection<MembreSetlist> MembreSetlist { get; set; } = new List<MembreSetlist>();
        public required ICollection<MembreJoueDe> Instruments { get; set; } = new List<MembreJoueDe>();
        public ICollection<MembreEvenement> MembreEvenements { get; set; } = new List<MembreEvenement>();
    }
}
