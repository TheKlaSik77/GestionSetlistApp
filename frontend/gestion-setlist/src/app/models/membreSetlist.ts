import { Membre } from "./membre";
import { Setlist } from "./setlist";

export interface MembreSetlist {
    membreId: number;
    membre: Membre;
    setlistId: number;
    setlist: Setlist;
}