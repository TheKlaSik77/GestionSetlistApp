import { Instrument } from "./instrument";
import { Membre } from "./membre";

export interface MembreJoueDe {
    membreId: number;
    membre: Membre;
    instrumentId: number;
    instrument: Instrument;
}