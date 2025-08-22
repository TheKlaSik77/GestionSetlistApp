namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record SetlistEvenementReadDTO
    {
        public required int EvenementId { get; set; }
        public required string? Nom { get; set; }
        public required DateTime Date { get; set; }
        public required string? Lieu { get; set; }       
    }
}