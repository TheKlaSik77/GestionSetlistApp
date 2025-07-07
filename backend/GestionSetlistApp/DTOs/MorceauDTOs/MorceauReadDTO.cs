using GestionSetlistApp.Models;
using GestionSetlistApp.DTOs.MorceauSetlistDTOs;


namespace GestionSetlistApp.DTOs.MorceauDTOs
{
    public record MorceauReadDTO
    {
        public int MorceauId { get; set; }
        public string Titre { get; set; }
        public string Artiste { get; set; }
        public string? Album { get; set; }
        public int DureeMorceau { get; set; }
        public ICollection<int> ListeIdSetlists { get; set; }

        public MorceauReadDTO(int morceauId, string titre, string artiste, string? album, int dureeMorceau, ICollection<int> listeIdSetlists)
        {
            MorceauId = morceauId;
            Titre = titre;
            Artiste = artiste;
            Album = album;
            DureeMorceau = dureeMorceau;
            ListeIdSetlists = listeIdSetlists ?? [];
        }
    }
}