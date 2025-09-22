import { Component, inject } from '@angular/core';
import { Morceau } from '../../../models/morceau';
import { MorceauxService } from '../../../services/morceaux/morceauxService';
import { RouterLink } from '@angular/router';
import { BarreRechercheEtFiltre } from '../../../components/barre-recherche-et-filtre/barre-recherche-et-filtre';
import { TypePage } from '../../../models/type-page';
import { MorceauItem } from '../../../components/morceaux/morceau-item/morceau-item';

@Component({
    selector: 'app-liste-morceaux',
    imports: [RouterLink,BarreRechercheEtFiltre,MorceauItem],
    templateUrl: './liste-morceaux.html',
    styleUrl: './liste-morceaux.scss',
})
export class ListeMorceaux {
    typePage = TypePage.Morceau;
    listeMorceaux: Morceau[];
    morceauxService: MorceauxService = inject(MorceauxService)

    constructor(){
        this.listeMorceaux = this.morceauxService.getMorceaux();
    }
}
