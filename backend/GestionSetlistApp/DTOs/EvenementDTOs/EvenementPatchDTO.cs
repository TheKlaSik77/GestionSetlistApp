namespace GestionSetlistApp.DTOs.EvenementDTOs
{
    public record EvenementPatchDTO
    {
        public string? Nom { get; set; }
        public DateTime? Date { get; set; }
        public string? Lieu { get; set; }
        public int? SetlistId { get; set; }
    }
}