import { Component, ElementRef, HostListener, input, output } from '@angular/core';
import { FILTRES_PAR_PAGE, TypePage } from '../../../models/type-page';

@Component({
    selector: 'app-filtre',
    imports: [],
    templateUrl: './filtre.html',
    styleUrl: './filtre.scss',
})
export class Filtre {
    menuOuvert: Boolean = false;
    majFiltre = output<string>();
    typePage = input<TypePage>();
    filtreActuel: string = '';
    AllFiltres: string[] = [];
    filtresDisponibles: string[] = [];
    elementsRecherche = output<{ recherche: string; filtreActuel: string }>();

    constructor(private elementRef: ElementRef) {}

    ngOnInit() {
        this.initialiserFiltres();
    }

    @HostListener('document:click', ['$event'])
    onDocumentClick(event: Event) {
        const target = event.target as HTMLElement;

        // Vérifier si le clic est en dehors de la div
        if (!this.elementRef.nativeElement.contains(target)) {
            if (this.menuOuvert === true) this.changerAffichageMenu();
        }
    }

    changerFiltreActuel(filtreActuel: string) {
        this.filtreActuel = filtreActuel;
        this.initialiserFiltres();
        this.changerAffichageMenu();
    }

    private initialiserFiltres() {
        const page = this.typePage();
        if (!page) return;

        this.AllFiltres = FILTRES_PAR_PAGE[page];
        if (this.filtreActuel === '') {
            this.filtreActuel = this.AllFiltres[0];
            console.log('coucou');
        }
        this.filtresDisponibles = this.AllFiltres.filter((f) => f !== this.filtreActuel);

        this.majFiltre.emit(this.filtreActuel);
    }

    changerAffichageMenu() {
        if (this.menuOuvert === false) {
            this.menuOuvert = true;
        } else {
            this.menuOuvert = false;
        }
    }
}
