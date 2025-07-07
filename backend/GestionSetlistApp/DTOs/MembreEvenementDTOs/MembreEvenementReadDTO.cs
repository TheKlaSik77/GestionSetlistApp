using GestionSetlistApp.DTOs.EvenementDTOs;
using GestionSetlistApp.DTOs.MembreDTOs;
using GestionSetlistApp.Models;

namespace GestionSetlistApp.DTOs.MembreEvenementDTOs
{
    public record MembreEvenementReadDTO
    {
        public int EvenementId { get; set; }
        public EvenementReadDTO? Evenement { get; set; }
        public int MembreId { get; set; }
        public MembreReadDTO? Membre { get; set; }

        public MembreEvenementReadDTO(int evenementId, EvenementReadDTO evenement, int membreId, MembreReadDTO membre)
        {
            EvenementId = evenementId;
            Evenement = evenement;
            MembreId = membreId;
            Membre = membre;
        }
    }
}