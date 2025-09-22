import { Injectable } from '@angular/core';
import { NotFoundError } from 'rxjs';
import { Morceau } from '../../models/morceau';

@Injectable({
    providedIn: 'root',
})
export class MorceauxService {
    listeMorceaux: Morceau[] = [
        {
            morceauId: 1,
            titre: 'Back in Black',
            artiste: 'AC/DC',
            album: 'Back in Black',
            dureeMorceau: 255,
            lienYoutube: 'https://www.youtube.com/watch?v=pAgnJDJN4VA',
            morceauSetlists: [],
        },
        {
            morceauId: 2,
            titre: 'Come Together',
            artiste: 'The Beatles',
            album: 'Abbey Road',
            dureeMorceau: 259,
            lienYoutube: 'https://www.youtube.com/watch?v=oolpPmuK2I8',
            morceauSetlists: [],
        },
    ];

    getMorceauById(id: number) : Morceau | undefined{
        return this.listeMorceaux.find(m => m.morceauId === id);
    }

    getMorceaux(): Morceau[]{
        return this.listeMorceaux;
    }

    lienYoutubeReplaceWatch(url: string){
        return url.replace('watch?v=','embed/');
    }
}
