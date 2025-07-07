
namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record SetlistReadDTO
    {
        public int SetlistId { get; set; }
        public string? NomSetlist { get; set; }
        public int DureeSetlist { get; set; }
        public ICollection<int> ListIdEvenements { get; set; }
        public ICollection<SetlistMorceauReadDTO> Morceaux { get; set; }
        public ICollection<int> ListeIdMembres { get; set; }

        public SetlistReadDTO(int setlistId, string nomSetlist, int dureeSetlist, ICollection<int> listeIdEvenements, ICollection<SetlistMorceauReadDTO> listeMorceaux, ICollection<int> listeIdMembres)
        {
            SetlistId = setlistId;
            NomSetlist = nomSetlist;
            DureeSetlist = dureeSetlist;
            ListIdEvenements = listeIdEvenements ?? [];
            Morceaux = listeMorceaux ?? [];
            ListeIdMembres = listeIdMembres ?? [];
        }
    }
}