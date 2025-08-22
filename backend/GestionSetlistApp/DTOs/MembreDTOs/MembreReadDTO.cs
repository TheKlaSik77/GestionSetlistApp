
namespace GestionSetlistApp.DTOs.MembreDTOs
{
    public record MembreReadDTO
    {
        public required int MembreId { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required int Age { get; set; }
        public required ICollection<MembreInstrumentReadDTO> ListeInstruments { get; set; }
    }
}