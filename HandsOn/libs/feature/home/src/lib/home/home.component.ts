import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ButtonComponent } from '@farm/ui';
import { map, Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { ThemeService } from '@farm/core';
import { ToggleSwitchModule } from 'primeng/toggleswitch';

@Component({
  selector: 'lib-home',
  imports: [CommonModule, RouterModule, ButtonComponent, ToggleSwitchModule, FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {

  isDarkMode$: Observable<boolean>;
  isDarkMode = false

  constructor(private themeService: ThemeService) {
    this.isDarkMode$ = this.themeService.theme$.pipe(map(theme => theme === 'dark'));

    this.isDarkMode$.subscribe(value => this.isDarkMode = value)

    this.themeService.initializeTheme();
  }

  toggleTheme() {
    this.themeService.toggleTheme();
  }
}
