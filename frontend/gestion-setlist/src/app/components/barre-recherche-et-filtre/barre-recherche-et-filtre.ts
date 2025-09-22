import { Component, input, output } from '@angular/core';
import { BarreRecherche } from './barre-recherche/barre-recherche';
import { Filtre } from './filtre/filtre';
import { TypePage } from '../../models/type-page';

@Component({
  selector: 'app-barre-recherche-et-filtre',
  imports: [BarreRecherche,Filtre],
  templateUrl: './barre-recherche-et-filtre.html',
  styleUrl: './barre-recherche-et-filtre.scss'
})
export class BarreRechercheEtFiltre {
  typePage = input<TypePage>();
  filtreActuel: string = "Titre";
  elementsRecherche = output<{recherche:string, filtreActuel: string}>();

  appliquerFiltre(filtre: string){
    this.filtreActuel = filtre;
  }

  appliquerRecherche(recherche: string){
    this.elementsRecherche.emit({recherche: recherche, filtreActuel: this.filtreActuel});
    console.log(recherche + ", " + this.filtreActuel);
  }
}
