namespace GestionSetlistApp.Models
{
    public class Membre
    {
        public int MembreId { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required DateTime DateNaissance { get; set; }
        public int Age { get; set; }
        public ICollection<MembreSetlist> MembreSetlist { get; set; } = [];
        public ICollection<MembreJoueDe> Instruments { get; set; } = [];
        public void CalculerAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateNaissance.Year;
            if (DateNaissance.Date > today.AddYears(-age))
            {
                age--;
            }
            Age = age;
        }
    }
}
