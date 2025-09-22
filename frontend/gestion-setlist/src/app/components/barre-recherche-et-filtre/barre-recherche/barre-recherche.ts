import { Component, inject, input, output } from '@angular/core';


@Component({
  selector: 'app-barre-recherche',
  templateUrl: './barre-recherche.html',
  styleUrl: './barre-recherche.scss'
})
export class BarreRecherche {
  typePage = input<string>();
  recherche = output<string>();

  renvoyerRecherche(valeur: string){
    this.recherche.emit(valeur);
  }
}
