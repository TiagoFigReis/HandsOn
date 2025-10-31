import { Route } from '@angular/router';

export const fertilizerTablesRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./fertilizer-tables/fertilizer-tables.component').then((m) => m.FertilizerTablesComponent),
    children: [
      {
        path: 'create',
        loadChildren: () => import('@farm/fertilizer-table').then((m) => m.fertilizerTableRoutes),
      },
      {
        path: ':id',
        loadChildren: () => import('@farm/fertilizer-table').then((m) => m.fertilizerTableRoutes),
      },
      {
        path: '**',
        redirectTo: '/404',
      },
    ],
  },
];
