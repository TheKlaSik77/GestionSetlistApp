using GestionSetlistApp.Models;
using GestionSetlistApp.DTOs.MorceauSetlistsDTOs;

namespace GestionSetlistApp.DTOs.MorceauxDTOs
{
    public record MorceauxReadDTO
    {
        public string Titre { get; set; }
        public string Artiste { get; set; }
        public string? Album { get; set; }
        public string? LienYoutube { get; set; }
        public string? LienSongsterr { get; set; }
        public int DureeMorceau { get; set; }
        public ICollection<MorceauSetlistsReadDTO>? MorceauSetlists { get; set; }

        public MorceauxReadDTO(string titre, string artiste, string? album, string? lienYoutube, string? lienSongsterr, int dureeMorceau, ICollection<MorceauSetlistsReadDTO>? morceauSetlistsDTO)
        {
            Titre = titre;
            Artiste = artiste;
            Album = album;
            LienYoutube = lienYoutube;
            LienSongsterr = lienSongsterr;
            DureeMorceau = dureeMorceau;
            MorceauSetlists = morceauSetlistsDTO;
        }
    }
}