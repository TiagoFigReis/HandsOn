import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HeaderComponent } from '@farm/header';
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

    this.userFacade.me().subscribe();
  }

  ngOnDestroy(): void {
    this.userFacade.reset();
  }

}
