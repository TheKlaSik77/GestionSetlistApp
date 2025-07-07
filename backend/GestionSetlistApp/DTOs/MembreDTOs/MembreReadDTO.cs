using GestionSetlistApp.DTOs.MembreSetlistDTOs;

namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record MembreReadDTO
    {
        public int MembreId { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int Age { get; set; }
        public ICollection<MembreSetlistReadDTO> MembreSetlists { get; set; }

        public MembreReadDTO(int membreId, string nom, string prenom, int age, ICollection<MembreSetlistReadDTO> membreSetlists)
        {
            MembreId = membreId;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            MembreSetlists = membreSetlists ?? [];
        }
    }
}