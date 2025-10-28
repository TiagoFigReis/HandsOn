import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Row } from '@farm/ui'; 
import { NutrientTablesListComponentFacade } from './nutrient-tables-list.component.facade';

@Component({
  selector: 'lib-nutrient-tables-list',
  imports: [CommonModule, RouterModule], 
  templateUrl: './nutrient-tables-list.component.html',
  styleUrl: './nutrient-tables-list.component.css',
})
export class NutrientTablesListComponent implements OnInit {
  data: Row[] = [];
  loading = false;
  isAdmin = false;

  constructor(private facade: NutrientTablesListComponentFacade) {}

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.nutrientTables$.subscribe((nutrientTables) => {
      this.data = nutrientTables;
    });

    this.facade.isAdmin$.subscribe((isAdmin) => {
      this.isAdmin = isAdmin;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }
}
