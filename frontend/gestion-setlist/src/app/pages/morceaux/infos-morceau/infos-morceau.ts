import { Component, inject } from '@angular/core';
import { Morceau } from '../../../models/morceau';
import { ActivatedRoute } from '@angular/router';
import { MorceauxService } from '../../../services/morceaux/morceauxService';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
    selector: 'app-infos-morceau',
    imports: [],
    templateUrl: './infos-morceau.html',
    styleUrl: './infos-morceau.scss',
})
export class InfosMorceau {
    route: ActivatedRoute = inject(ActivatedRoute);
    morceauxService = inject(MorceauxService);
    morceau?: Morceau;
    lienYoutubeSanitised?: SafeResourceUrl;

    constructor(private sanitizer: DomSanitizer) {
        const id = parseInt(this.route.snapshot.params['id'], 10);
        this.morceau = this.morceauxService.getMorceauById(id);

        if (this.morceau && this.morceau.lienYoutube) {
            this.lienYoutubeSanitised = this.sanitizer.bypassSecurityTrustResourceUrl(
                this.morceauxService.lienYoutubeReplaceWatch(this.morceau.lienYoutube)
            );
        }
    }
}
