import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'test' },
    {
        path: 'test',
        loadComponent: () =>
        import('./test/comp-test/comp-test')
            .then(m => m.CompTest),
    },
    { path: '**', redirectTo: 'test' }
];