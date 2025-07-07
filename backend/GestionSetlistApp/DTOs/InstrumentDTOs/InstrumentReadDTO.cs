using GestionSetlistApp.DTOs.MembreDTOs;

namespace GestionSetlistApp.DTOs.InstrumentDTOs
{
    public record InstrumentReadDTO
    {
        public int InstrumentId { get; set; }
        public string? Nom { get; set; }
        public string? Role { get; set; }
        public ICollection<MembreReadDTO> Membres { get; set; }

        public InstrumentReadDTO(int instrumentId, string nom, string role, ICollection<MembreReadDTO> membres)
        {
            InstrumentId = instrumentId;
            Nom = nom;
            Role = role;
            Membres = membres ?? [];
        }

    }
}