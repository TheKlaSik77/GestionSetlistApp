import { Membre } from "./membre";

export interface Instrument {
    instrumentId: number;
    nom: string;
    membres: Membre[];
}