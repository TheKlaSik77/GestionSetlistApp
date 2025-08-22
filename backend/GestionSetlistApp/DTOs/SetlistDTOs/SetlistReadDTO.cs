
namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record SetlistReadDTO
    {
        public int SetlistId { get; set; }
        public string? NomSetlist { get; set; }
        public int DureeSetlist { get; set; }
        public ICollection<SetlistEvenementReadDTO> ListeEvenements { get; set; }
        public ICollection<SetlistMorceauReadDTO> ListeMorceaux { get; set; }
        public ICollection<SetlistMembreReadDTO> ListeMembres { get; set; }

        public SetlistReadDTO(int setlistId, string nomSetlist, int dureeSetlist, ICollection<SetlistEvenementReadDTO> listeEvenements, ICollection<SetlistMorceauReadDTO> listeMorceaux, ICollection<SetlistMembreReadDTO> listeMembres)
        {
            SetlistId = setlistId;
            NomSetlist = nomSetlist;
            DureeSetlist = dureeSetlist;
            ListeEvenements = listeEvenements ?? [];
            ListeMorceaux = listeMorceaux ?? [];
            ListeMembres = listeMembres ?? [];
        }
    }
}