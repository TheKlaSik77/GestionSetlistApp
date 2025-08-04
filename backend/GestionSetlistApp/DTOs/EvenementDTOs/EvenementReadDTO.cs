using GestionSetlistApp.DTOs.SetlistDTOs;
using GestionSetlistApp.DTOs.MembreEvenementDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.DTOs.EvenementDTOs
{
    public record EvenementReadDTO
    {
        public int EvenementId { get; set; }
        public string? Nom { get; set; }
        public DateTime Date { get; set; }
        public string? Lieu { get; set; }
        public int? SetlistId { get; set; }
        public ICollection<int> ListeMembres { get; set; }

        public EvenementReadDTO(int evenementId, string nom, DateTime date, string lieu, int? setlistId, ICollection<int> listeMembres)
        {
            EvenementId = evenementId;
            Nom = nom;
            Date = date;
            Lieu = lieu;
            SetlistId = setlistId;
            ListeMembres = listeMembres ?? [];

        }
    }
}