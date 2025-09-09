import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from '@farm/header';
import { SidebarComponent } from '@farm/sidebar';
import { MainComponent } from '@farm/main';
import { FooterComponent } from '@farm/footer';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { MenuItem } from 'primeng/api';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { UserFacade } from '@farm/core';
import { SpinnerComponent } from '@farm/ui';

@Component({
  selector: 'lib-master-page',
  imports: [
    CommonModule,
    RouterModule,
    HeaderComponent,
    SidebarComponent,
    MainComponent,
    FooterComponent,
    TieredMenuModule,
    ProgressSpinnerModule,
    SpinnerComponent,
  ],
  templateUrl: './master-page.component.html',
  styleUrl: './master-page.component.css',
})
export class MasterPageComponent implements OnInit, OnDestroy {
  menuItems: MenuItem[] = [];
  menuVisible = false;
  loading = true;

  constructor(private userFacade: UserFacade) { }

  ngOnInit(): void {
    this.userFacade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.userFacade.me().subscribe((user) => {
      this.loadMenu(user.role as string);
    });
  }

  ngOnDestroy(): void {
    this.userFacade.reset();
  }

  loadMenu(userRole: string) {
    const menuItems: MenuItem[] = [];

    if (userRole === 'Admin') {
      menuItems.push({
        label: 'Usuários',
        icon: 'pi pi-fw pi-users',
        items: [
          {
            label: 'Cadastrar',
            icon: 'pi pi-fw pi-user-plus',
            routerLink: '/app/users/create',
          },
          {
            label: 'Gerenciar',
            icon: 'pi pi-fw pi-users',
            routerLink: '/app/users',
          },
        ],
      });

      menuItems.push({
        label: 'Culturas',
        icon: 'pi pi-fw pi-whatsapp',
        items: [
          {
            label: 'Gerenciar',
            icon: 'pi pw-fw pi-cog',
            routerLink: '/app/cultures'
          }
        ]
      });
    }

    if (userRole === 'Owner') {
      menuItems.push({
        label: 'Análises',
        icon: 'fas fa-chart-simple',
        items: [
          {
            label: 'Adicionar Análise',
            icon: 'pi pi-fw pi-plus-circle',
            routerLink: '/app/analises/create',
          },
          {
            label: 'Gerenciar Análises',
            icon: 'pi pi-fw pi-cog',
            routerLink: '/app/analises',
          },
        ]
      });
    }

    if (userRole === "Consultant" || userRole === "Owner" || userRole === "Admin") {
      menuItems.push({
        label: 'Tabelas de Recomendação',
        icon: 'pi pi-fw pi-table',
        items: [
          {
            label: 'Gerenciar Tabelas de Nutrientes',
            icon: 'pi pi-fw pi-percentage',
            routerLink: '/app/nutrientTables'
          },
          {
            label: 'Gerenciar Tabelas de Fertilizantes',
            icon: 'pi pi-fw pi-bolt',
            routerLink: '/app/fertilizerTables'
          },
          {
            label: 'Gerenciar Tabelas de Formulados',
            icon: 'pi pi-fw pi-chart-line',
            routerLink: '/app/formulationTables'
          }
        ]
      })
    }

    this.menuItems = menuItems;
  }
}
