namespace GestionSetlistApp.DTOs.EvenementDTOs
{
    public record EvenementCreateDTO
    {
        public required string Nom { get; set; }
        public required DateTime Date { get; set; }
        public required string Lieu { get; set; }

        public EvenementCreateDTO(string nom, DateTime date, string lieu)
        {
            Nom = nom;
            Date = date;
            Lieu = lieu;
        }
    }
}