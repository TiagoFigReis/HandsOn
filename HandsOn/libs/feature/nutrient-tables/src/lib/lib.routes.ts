import { Route } from '@angular/router';

export const nutrientTablesRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('./nutrient-tables/nutrient-tables.component').then((m) => m.NutrientTablesComponent),
    children: [
      {
        path: '',
        loadChildren: () =>
          import('@farm/nutrient-tables-list').then((m) => m.nutrientTablesListRoutes),
      },
      {
        path: 'create',
        loadChildren: () => import('@farm/nutrient-table').then((m) => m.nutrientTableRoutes),
      },
      {
        path: ':id',
        loadChildren: () => import('@farm/nutrient-table').then((m) => m.nutrientTableRoutes),
      },
    ],
  },
];
