using GestionSetlistApp.Models;

namespace GestionSetlistApp.Repositories
{
    public class MorceauxRepository : IMorceauxRepository
    {
        // Ici on implémente le dbContext
        public List<Morceau> Morceaux = new List<Morceau>
            {
                new Morceau
                {
                    MorceauId = 1,
                    Titre = "Bohemian Rhapsody",
                    Artiste = "Queen",
                    Album = "A Night at the Opera",
                    LienYoutube = "https://www.youtube.com/watch?v=fJ9rUzIMcZQ",
                    LienSongsterr = "https://www.songsterr.com/a/wsa/queen-bohemian-rhapsody-tab-s326",
                    DureeMorceau = 355
                },
                new Morceau
                {
                    MorceauId = 2,
                    Titre = "Smells Like Teen Spirit",
                    Artiste = "Nirvana",
                    Album = "Nevermind",
                    LienYoutube = "https://www.youtube.com/watch?v=hTWKbfoikeg",
                    LienSongsterr = "https://www.songsterr.com/a/wsa/nirvana-smells-like-teen-spirit-tab-s68",
                    DureeMorceau = 301
                },
                new Morceau
                {
                    MorceauId = 3,
                    Titre = "Billie Jean",
                    Artiste = "Michael Jackson",
                    Album = "Thriller",
                    LienYoutube = "https://www.youtube.com/watch?v=Zi_XLOBDo_Y",
                    LienSongsterr = "https://www.songsterr.com/a/wsa/michael-jackson-billie-jean-tab-s38926",
                    DureeMorceau = 294
                },
                new Morceau
                {
                    MorceauId = 4,
                    Titre = "Hotel California",
                    Artiste = "Eagles",
                    Album = "Hotel California",
                    LienYoutube = "https://www.youtube.com/watch?v=EqPtz5qN7HM",
                    LienSongsterr = "https://www.songsterr.com/a/wsa/eagles-hotel-california-tab-s193t1",
                    DureeMorceau = 391
                },
                new Morceau
                {
                    MorceauId = 5,
                    Titre = "Sweet Child O' Mine",
                    Artiste = "Guns N' Roses",
                    Album = "Appetite for Destruction",
                    LienYoutube = "https://www.youtube.com/watch?v=1w7OgIMMRc4",
                    LienSongsterr = "https://www.songsterr.com/a/wsa/guns-n-roses-sweet-child-o-mine-tab-s483",
                    DureeMorceau = 356
                }
            };

        public List<Morceau> GetAll()
        {
            return Morceaux;
        }


    }
}