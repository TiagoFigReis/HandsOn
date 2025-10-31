import { Route } from '@angular/router';

export const usersRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./users/users.component').then((m) => m.UsersComponent),
    children: [
      {
        path: 'create',
        loadChildren: () => import('@farm/user').then((m) => m.userRoutes),
      },
      {
        path: ':id',
        loadChildren: () => import('@farm/user').then((m) => m.userRoutes),
      },
      {
        path: '**',
        redirectTo: '/404',
      },
    ],
  },
];
