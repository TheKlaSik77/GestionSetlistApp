using GestionSetlistApp.Models;
using GestionSetlistApp.DTOs.MorceauSetlistsDTOs;

namespace GestionSetlistApp.DTOs.MorceauxDTOs
{
    public record MorceauxReadDTO
    {
        public int MorceauId { get; set; }
        public string Titre { get; set; }
        public string Artiste { get; set; }
        public string? Album { get; set; }
        public string? LienYoutube { get; set; }
        public int DureeMorceau { get; set; }
        public ICollection<MorceauSetlistsReadDTO>? MorceauSetlists { get; set; }

        public MorceauxReadDTO(int morceauId, string titre, string artiste, string? album, string? lienYoutube, int dureeMorceau, ICollection<MorceauSetlistsReadDTO>? morceauSetlistsDTO)
        {
            MorceauId = morceauId;
            Titre = titre;
            Artiste = artiste;
            Album = album;
            LienYoutube = lienYoutube;
            DureeMorceau = dureeMorceau;
            MorceauSetlists = morceauSetlistsDTO;
        }
    }
}