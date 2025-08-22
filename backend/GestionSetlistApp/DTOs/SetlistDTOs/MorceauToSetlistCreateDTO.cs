namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record MorceauToSetlistCreateDTO
    {
        public required int MorceauId { get; set; }
        public int? PositionMorceauDansSetlist { get; set; }
    }
}