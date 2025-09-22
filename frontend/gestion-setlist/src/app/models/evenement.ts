import { Setlist } from "./setlist";

export interface Evenement {
    evenementId: number;
    nom: string;
    date: Date;
    lieu: string;
    setlistId: number | undefined;
    setlist: Setlist | undefined;
}
