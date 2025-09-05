import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Column, TableComponent, Row } from '@farm/ui';
import { FertilizerTablesListComponentFacade } from './fertilizer-tables-list.component.facade';

@Component({
  selector: 'lib-fertilizer-tables-list',
  imports: [CommonModule, TableComponent],
  templateUrl: './fertilizer-tables-list.component.html',
  styleUrl: './fertilizer-tables-list.component.css',
})
export class FertilizerTablesListComponent implements OnInit {
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: FertilizerTablesListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.fertilizerTables$.subscribe((fertilizerTables) => {
      this.data = fertilizerTables;
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