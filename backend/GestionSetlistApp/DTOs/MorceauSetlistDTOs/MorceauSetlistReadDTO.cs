namespace GestionSetlistApp.DTOs.MorceauSetlistDTOs
{
    public record MorceauSetlistReadDTO
    {
        public int SetlistId { get; set; }
        public string? NomSetlist { get; set; }
        public int PositionMorceauDansSetlist { get; set; }

        public MorceauSetlistReadDTO(int setlistId, string nomSetlist, int positionMorceauDansSetlist)
        {
            SetlistId = setlistId;
            NomSetlist = nomSetlist;
            PositionMorceauDansSetlist = positionMorceauDansSetlist;
        }

    }
}