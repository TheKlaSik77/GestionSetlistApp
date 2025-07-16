
using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.DTOs.SetlistDTOs;

namespace GestionSetlistApp.DTOs.MembreSetlistDTOs
{
    public record MembreSetlistReadDTO
    {
        public int MembreId { get; set; }
        public string NomInstrument { get; set; }

        public MembreSetlistReadDTO(int membreId, string nomInstrument)
        {
            MembreId = membreId;
            NomInstrument = nomInstrument;
        }
    }
}