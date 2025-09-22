import { MorceauSetlist } from "./morceauSetlist";

export interface Morceau {
    morceauId: number;
    titre: string;
    artiste: string;
    album: string;
    dureeMorceau: number;
    lienYoutube: string;
    morceauSetlists: MorceauSetlist[];
}

