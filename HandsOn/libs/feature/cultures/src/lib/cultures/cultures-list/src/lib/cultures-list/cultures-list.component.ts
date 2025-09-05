import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Column, Row, TableCulturesComponent } from '@farm/ui';
import { CulturesListComponentFacade } from './cultures-list.component.facade';
import { Culture } from '@farm/core';

@Component({
  selector: 'lib-cultures-list',
  imports: [CommonModule, TableCulturesComponent],
  templateUrl: './cultures-list.component.html',
  styleUrl: './cultures-list.component.css',
})
export class CulturesListComponent implements OnInit {
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: CulturesListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.cultures$.subscribe((culture) => {
      this.data = culture;
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }

  onSubmit(culture: Culture) {
    this.facade.submit(culture);
  }
}

const columns: Column[] = [
  {
    field: 'name',
    header: 'Nome',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  }
];