import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Column, Row, TableComponent } from '@farm/ui';
import { FormulationTablesListComponentFacade } from './formulation-tables-list.component.facade';

@Component({
  selector: 'lib-formulation-tables-list',
  imports: [CommonModule, TableComponent],
  templateUrl: './formulation-tables-list.component.html',
  styleUrl: './formulation-tables-list.component.css',
})
export class FormulationTablesListComponent {
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;
  isAdmin = false;

  constructor(private facade: FormulationTablesListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.formulationTables$.subscribe((formulationTables) => {
      this.data = formulationTables;
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