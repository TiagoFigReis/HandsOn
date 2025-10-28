import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ThemeService } from '@farm/core';
import { ConfirmDialogComponent, ToastComponent } from '@farm/ui';
import { ButtonModule } from 'primeng/button';

@Component({
  imports: [RouterModule, ConfirmDialogComponent, ToastComponent, ButtonModule],
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'Gestão Agrícola';

  constructor(
    private themeService: ThemeService
  ) {
   
  }
}


