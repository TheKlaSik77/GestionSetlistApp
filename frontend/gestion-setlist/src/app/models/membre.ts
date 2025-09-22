import { MembreJoueDe } from "./membreJoueDe";
import { MembreSetlist } from "./membreSetlist";

export interface Membre {
    membreId: number;
    nom: string;
    prenom: string;
    dateNaissance: Date;
    age: number;
    membreSetlists: MembreSetlist[];
    instruments: MembreJoueDe[];
}