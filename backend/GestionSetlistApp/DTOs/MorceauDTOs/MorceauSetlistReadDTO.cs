namespace GestionSetlistApp.DTOs.MorceauSetlistDTOs
{
    public record MorceauSetlistReadDTO
    {
        public required int SetlistId { get; set; }
        public required string NomSetlist { get; set; }
        public required int PositionMorceauDansSetlist { get; set; }

    }
}