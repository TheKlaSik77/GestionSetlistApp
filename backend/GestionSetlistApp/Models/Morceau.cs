public class Morceau
{
    public int MorceauId { get; set; }
    public string Titre { get; set; } = "";
    public string Artiste { get; set; } = "";
    public string Album { get; set; } = "";
    public string LienYoutube { get; set; } = "";
    public string LienSongsterr { get; set; } = "";
    public int DureeMorceau { get; set; }

    public ICollection<MorceauSetlist> Setlists { get; set; } = new List<MorceauSetlist>();
    


}