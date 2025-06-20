namespace GestionSetlistApp.DTOs.MorceauxDTOs
{
    public record MorceauxReadDTO
    {
        public string Titre { get; set; }
        public string Artiste { get; set; }

        public MorceauxReadDTO(string titre, string artiste)
        {
            Titre = titre;
            Artiste = artiste;
        }
    }
}