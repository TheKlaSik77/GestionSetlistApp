
using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs;

namespace GestionSetlistApp.DTOs.MembreSetlistDTOs
{
    public record MembreSetlistReadDTO
    {
        public int MembreId { get; set; }
        public MembreReadDTO? Membre { get; set; }
        public int SetlistId { get; set; }
        public SetlistReadDTO? Setlist { get; set; }

        public MembreSetlistReadDTO(int membreId, MembreReadDTO membre, int setlistId, SetlistReadDTO setlist)
        {
            MembreId = membreId;
            Membre = membre;
            SetlistId = setlistId;
            Setlist = setlist;

        }
    }
}