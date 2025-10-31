import { Route } from '@angular/router';

export const analisesRoutes: Route[] = [
    {
        path: '',
        loadComponent: () =>
        import('./analises/analises.component').then((m) => m.AnalisesComponent),
        children: [
            {
                path: 'create',
                loadChildren: () => import('@farm/analise').then((m) => m.AnaliseRoutes)
            },
            {
                path: ':id',
                loadChildren: () => import('@farm/analise').then((m) => m.AnaliseRoutes)
            },
            {
                path: 'results/:id',
                loadChildren: () => import('@farm/result_analises').then((m) => m.ResultAnalisesRoutes)
            },
            {
                path: '**',
                redirectTo: '/404',
            },
        ]
    }
]