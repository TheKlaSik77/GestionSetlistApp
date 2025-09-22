import { Routes } from '@angular/router';
import { ListeMorceaux } from './pages/morceaux/liste-morceaux/liste-morceaux';
import { InfosMorceau } from './pages/morceaux/infos-morceau/infos-morceau';
import { AjouterMorceau } from './pages/morceaux/ajouter-morceau/ajouter-morceau';

const routeConfig: Routes = [
    {
        path: 'morceaux',
        component: ListeMorceaux,
        title: 'Liste Morceaux',
    },
    {
        path: 'morceaux/details/:id',
        component: InfosMorceau,
        title: "Informations Morceaux"
    },
    {
        path: 'morceaux/ajouterMorceau',
        component: AjouterMorceau,
        title: "Ajouter Morceau"
    }

];

export default routeConfig;