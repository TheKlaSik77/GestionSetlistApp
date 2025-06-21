namespace GestionSetlistApp.DTOs.MorceauSetlistsDTOs
{
    public record MorceauSetlistsReadDTO
    {
        public int SetlistId { get; set; }
        public string? NomSetlist { get; set; }
        public int PositionMorceauDansSetlist { get; set; }

        public MorceauSetlistsReadDTO(int setlistId, string nomSetlist, int positionMorceauDansSetlist)
        {
            SetlistId = setlistId;
            NomSetlist = nomSetlist;
            PositionMorceauDansSetlist = positionMorceauDansSetlist;
        }

    }
}