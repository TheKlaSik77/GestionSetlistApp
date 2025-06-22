namespace GestionSetlistApp.Models
{
    public class Morceau
    {
        public int MorceauId { get; set; }
        public required string Titre { get; set; }
        public required string Artiste { get; set; }
        public string? Album { get; set; }
        public string? LienYoutube { get; set; }
        public int DureeMorceau { get; set; }

        public ICollection<MorceauSetlist> MorceauSetlists { get; set; } = new List<MorceauSetlist>();
    }
}