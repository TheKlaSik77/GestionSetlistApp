using GestionSetlistApp.DTOs.MembreSetlistDTOs;

namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record MembreCreateDTO
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }

        public MembreCreateDTO(string nom, string prenom, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }
    }
}