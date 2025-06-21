namespace GestionSetlistApp.Models
{
    public class Setlist
    {
        public int SetlistId { get; set; }
        public required string NomSetlist { get; set; }
        public int? DureeSetlist { get; set; }
        public ICollection<Evenement>? Evenements { get; set; } = new List<Evenement>();
        public ICollection<MorceauSetlist>? MorceauSetlists { get; set; } = new List<MorceauSetlist>();
        public ICollection<MembreSetlist>? MembreSetlist { get; set; } = new List<MembreSetlist>();

    }
}