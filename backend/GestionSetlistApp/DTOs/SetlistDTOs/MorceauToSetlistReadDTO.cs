namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record MorceauToSetlistReadDTO
    {
        public required int MorceauId { get; set; }
        public int PositionMorceauDansSetlist { get; set; }
    }
}