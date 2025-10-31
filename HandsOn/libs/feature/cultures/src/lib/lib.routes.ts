import { Route } from '@angular/router';

export const culturesRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./cultures/cultures.component').then((m) => m.CulturesComponent),
    children: [
      {
        path: ':id',
        loadChildren: () => import('@farm/culture').then((m) => m.cultureRoutes),
      },
      {
        path: '**',
        redirectTo: '/404',
      },
    ],
  },
];
