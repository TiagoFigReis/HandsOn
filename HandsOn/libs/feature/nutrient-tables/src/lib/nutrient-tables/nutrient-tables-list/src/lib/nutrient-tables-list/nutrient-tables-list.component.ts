import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Column, TableComponent, Row } from '@farm/ui';
import { NutrientTablesListComponentFacade } from './nutrient-tables-list.component.facade';

@Component({
  selector: 'lib-nutrient-tables-list',
  imports: [CommonModule, TableComponent],
  templateUrl: './nutrient-tables-list.component.html',
  styleUrl: './nutrient-tables-list.component.css',
})
export class NutrientTablesListComponent implements OnInit {
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;
  isAdmin = false;

  constructor(private facade: NutrientTablesListComponentFacade) {
    this.columns = columns;
  }

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

const columns: Column[] = [
  {
    field: 'cultureName',
    header: 'Cultura',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true
  },
  {
    field: "standardText",
    header: "Personalizada",
    type: "text",
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true
  }
];