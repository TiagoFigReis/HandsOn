import { Component } from '@angular/core';
import { CommonModule, NgClass } from '@angular/common'; // Importe NgClass
import { RouterLink } from '@angular/router';
import { AnalisesListComponent } from "@farm/analises-list";
import { NutrientTablesListComponent } from "@farm/nutrient-tables-list";
import { FertilizerTablesListComponent } from "@farm/fertilizer-tables-list";

@Component({
  selector: 'lib-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    NgClass, 
    RouterLink,
    AnalisesListComponent,
    NutrientTablesListComponent,
    FertilizerTablesListComponent
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent {
  
  public activeTab: 'sobre' | 'analises' | 'tabelas' = 'sobre';

  setActiveTab(tab: 'sobre' | 'analises' | 'tabelas') {
    this.activeTab = tab;
  }
}