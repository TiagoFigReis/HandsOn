import { Route } from '@angular/router';
import { AuthenticatedGuard, IsAdminGuard } from '@farm/core';

export const masterPageRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./master-page/master-page.component').then(
        (m) => m.MasterPageComponent,
      ),
    canActivate: [AuthenticatedGuard],
    children: [
      {
        path: '',
        loadChildren: () =>
          import('@farm/dashboard').then((m) => m.dashboardRoutes),
      },
      {
        path: 'users',
        loadChildren: () => import('@farm/users').then((m) => m.usersRoutes),
        canActivate: [IsAdminGuard],
      },
      {
        path: 'analises',
        loadChildren: () => import('@farm/analises').then((m) => m.analisesRoutes),
      },
      {
        path: 'nutrientTables',
        loadChildren: () => import('@farm/nutrient-tables').then((m) => m.nutrientTablesRoutes)
      },
      {
        path: 'fertilizerTables',
        loadChildren: () => import('@farm/fertilizer-tables').then((m) => m.fertilizerTablesRoutes)
      },
      {
        path: 'cultures',
        loadChildren: () => import('@farm/cultures').then((m) => m.culturesRoutes)
      },
      {
        path: 'settings',
        loadChildren: () =>
          import('@farm/settings').then((m) => m.settingsRoutes),
      },
      {
        path: '**',
        redirectTo: 'not-found',
      },
    ],
  },
];
