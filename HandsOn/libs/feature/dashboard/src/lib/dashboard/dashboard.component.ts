import { Component, OnInit } from '@angular/core';
import { CommonModule, NgClass } from '@angular/common'; // Importe NgClass
import { RouterLink } from '@angular/router';
import { AnalisesListComponent } from "@farm/analises-list";
import { NutrientTablesListComponent } from "@farm/nutrient-tables-list";
import { FertilizerTablesListComponent } from "@farm/fertilizer-tables-list";
import { CulturesListComponent} from "@farm/cultures-list"
import { User, UserFacade, UserRoles } from '@farm/core';
import { UsersListComponent} from "@farm/users-list"
import { ButtonComponent } from '@farm/ui';

@Component({
  selector: 'lib-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    NgClass, 
    RouterLink,
    AnalisesListComponent,
    NutrientTablesListComponent,
    FertilizerTablesListComponent,
    CulturesListComponent, 
    UsersListComponent,
    ButtonComponent
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
  
  public activeTab: 'sobre' | 'analises' | 'tabelas' | 'culturas' | 'users'  = 'sobre';

  private user : User | null = null

  constructor(private userFacade: UserFacade) {}

  get userRole(): string {
    if (!this.user) return '';

    return UserRoles[this.user.role as keyof typeof UserRoles];
  }

  ngOnInit(): void {
    this.userFacade.user$.subscribe((user) => {
      this.user = user;
    });
  }

  setActiveTab(tab: 'sobre' | 'analises' | 'tabelas' | 'culturas' | 'users') {
    this.activeTab = tab;
  }
}