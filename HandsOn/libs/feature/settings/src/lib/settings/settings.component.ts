import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MenuComponent } from '@farm/ui';
import { MenuItem } from 'primeng/api';
import { ThemeService } from '@farm/core';
import { Observable, map } from 'rxjs';
import { InputSwitchModule } from 'primeng/inputswitch';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'lib-settings',
  imports: [
    CommonModule,
    RouterModule,
    MenuComponent,
    InputSwitchModule,
    FormsModule,
  ],
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css',
})
export class SettingsComponent {
  isDarkMode$: Observable<boolean>;

  menuItems: MenuItem[] = [
    {
      label: 'Conta',
      icon: 'pi pi-fw pi-user',
      routerLink: '/app/settings/account',
      styleClass: 'description',
    },
    {
      label: 'Segurança',
      icon: 'pi pi-fw pi-lock',
      routerLink: '/app/settings/security',
      styleClass: 'description',
    },
  ];

  constructor(private themeService: ThemeService) {
    this.isDarkMode$ = this.themeService.theme$.pipe(
      map((theme) => theme === 'dark')
    );
  }

  toggleTheme() {
    this.themeService.toggleTheme();
  }
}
