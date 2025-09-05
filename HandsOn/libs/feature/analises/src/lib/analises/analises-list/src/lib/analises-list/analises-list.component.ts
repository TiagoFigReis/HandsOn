import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableComponent, Column, Row } from '@farm/ui';
import { AnalisesListComponentFacade } from './analises-list.component.facade';

@Component({
  selector: 'lib-analises-list',
  imports: [CommonModule, TableComponent],
  templateUrl: './analises-list.component.html',
  styleUrl: './analises-list.component.css',
})
export class AnalisesListComponent implements OnInit{
  data: Row[] = [];
  columns: Column[];
  loading = false;
  showMoreButton = true;

  constructor(private facade: AnalisesListComponentFacade) {
    this.columns = columns;
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.analises$.subscribe((analises) => {
      this.data = analises
    });

    this.facade.load();
  }

  refresh() {
    this.facade.load();
  }
}

const columns: Column[] = [
  {
    field: 'tipo',
    header: 'Tipo',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'lab',
    header: 'Laboratório',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'dataAnalise',
    header: 'Data da Análise',
    type: 'date',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  
  {
    field: 'proprietario',
    header: 'Proprietario',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'propriedade',
    header: 'Propriedade',
    type: 'text',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,

  },
  {
    field: 'createdAt',
    header: 'Criado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'updatedAt',
    header: 'Atualizado em',
    type: 'datetime',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
  {
    field: 'blob',
    header: 'Análise',
    type: 'file',
    sortable: true,
    filterable: true,
    visible: true,
    showToUser: true,
  },
]