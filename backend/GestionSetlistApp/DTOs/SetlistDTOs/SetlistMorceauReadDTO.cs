namespace GestionSetlistApp.DTOs.SetlistDTOs
{
    public record SetlistMorceauReadDTO
    {
        public int MorceauId { get; set; }
        public int PositionMorceauDansSetlist { get; set; }

        public SetlistMorceauReadDTO(int morceauId, int positionMorceauDansSetlist)
        {
            MorceauId = morceauId;
            PositionMorceauDansSetlist = positionMorceauDansSetlist;
        }

    }
}