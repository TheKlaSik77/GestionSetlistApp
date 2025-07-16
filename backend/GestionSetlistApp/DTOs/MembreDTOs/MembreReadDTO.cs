using GestionSetlistApp.DTOs.MembreSetlistDTOs;

namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record MembreReadDTO
    {
        public int MembreId { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public int Age { get; set; }
        public ICollection<int> ListeSetlists { get; set; }
        public ICollection<int> ListeInstruments { get; set; }
        public ICollection<int> ListeEvenements { get; set; }


        public MembreReadDTO(int membreId, string nom, string prenom, int age, ICollection<int> listeSetlists, ICollection<int> listeInstruments, ICollection<int> listeEvenements)
        {
            MembreId = membreId;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            ListeSetlists = listeSetlists ?? [];
            ListeInstruments = listeInstruments ?? [];
            ListeEvenements = listeEvenements ?? [];
        }
    }
}