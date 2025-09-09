import { Route } from '@angular/router';

export const formulationTablesRoutes: Route[] = [
    {
        path: '',
        loadComponent: () =>
            import('./formulation-tables/formulation-tables.component').then((m) => m.FormulationTablesComponent),
        children: [
            {
                path: '',
                loadChildren: () =>
                    import('@farm/formulation-tables-list').then((m) => m.formulationTablesListRoutes),
            },
            {
                path: 'create',
                loadChildren: () => import('@farm/formulation-table').then((m) => m.formulationTableRoutes),
            },
            {
                path: ':id',
                loadChildren: () => import('@farm/formulation-table').then((m) => m.formulationTableRoutes),
            },
        ],
    },
];
