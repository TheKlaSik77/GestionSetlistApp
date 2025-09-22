import { Evenement } from "./evenement";
import { MembreSetlist } from "./membreSetlist";
import { MorceauSetlist } from "./morceauSetlist";

export interface Setlist {
    setlistId: number;
    nomSetlist: string;
    dureeSetlist: number;
    evenements: Evenement[];
    morceauxSetlists: MorceauSetlist[];
    membres: MembreSetlist[];
}
