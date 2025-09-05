import { Route } from '@angular/router';

export const culturesRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./cultures/cultures.component').then((m) => m.CulturesComponent),
    children: [
      {
        path: '',
        loadChildren: () =>
          import('@farm/cultures-list').then((m) => m.culturesListRoutes),
      },
      {
        path: ':id',
        loadChildren: () => import('@farm/culture').then((m) => m.cultureRoutes),
      },
    ],
  },
];
