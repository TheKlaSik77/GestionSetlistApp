namespace GestionSetlistApp.Models
{
    public class Setlist
    {
        public int SetlistId { get; set; }
        public required string NomSetlist { get; set; }
        public int DureeSetlist { get; set; }
        public ICollection<Evenement> Evenements { get; set; } = [];
        public ICollection<MorceauSetlist> MorceauSetlists { get; set; } = [];
        public ICollection<MembreSetlist> MembreSetlist { get; set; } = [];

    }
}