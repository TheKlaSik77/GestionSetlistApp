import { Morceau } from "./morceau";
import { Setlist } from "./setlist";

export interface MorceauSetlist {
    morceauId: number;
    morceau: Morceau;
    setlistId: number;
    setlist: Setlist;
    position: number;
}
