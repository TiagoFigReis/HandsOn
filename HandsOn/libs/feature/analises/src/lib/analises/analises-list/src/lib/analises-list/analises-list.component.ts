import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { AnalisesListComponentFacade, AnalyseWithActions } from './analises-list.component.facade';

import { ButtonComponent } from '@farm/ui';
import { InputComponent } from '@farm/ui'; 
import { SelectComponent, SelectOption } from '@farm/ui'; 

@Component({
  selector: 'lib-analises-list',
  imports: [
    CommonModule,
    RouterLink,
    ReactiveFormsModule,
    ButtonComponent,
    InputComponent,
    SelectComponent,
  ],
  templateUrl: './analises-list.component.html',
  styleUrl: './analises-list.component.css',
})
export class AnalisesListComponent implements OnInit {
  allAnalyses: AnalyseWithActions[] = [];
  filteredAnalyses: AnalyseWithActions[] = [];
  loading = false;

  typeOptions: SelectOption[] = [
    { label: 'Todos os Tipos', value: 'all' },
    { label: 'Solo', value: 'Solo' },
    { label: 'Foliar', value: 'Foliar' },
  ];

  sortOptions: SelectOption[] = [
    { label: 'Mais Recentes', value: 'recent' },
    { label: 'Mais Antigas', value: 'oldest' },
  ];

  filterTypeControl = new FormControl<SelectOption>(this.typeOptions[0]);
  filterStartDateControl = new FormControl<string | null>(null);
  filterEndDateControl = new FormControl<string | null>(null);
  dateSortOrderControl = new FormControl<SelectOption>(this.sortOptions[0]);

  

  constructor(private facade: AnalisesListComponentFacade) {}

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.analises$.subscribe((analises) => {
      this.allAnalyses = analises;
      this.applyFiltersAndSorting();
    });

    this.filterTypeControl.valueChanges.subscribe(() => this.applyFiltersAndSorting());
    this.filterStartDateControl.valueChanges.subscribe(() => this.applyFiltersAndSorting());
    this.filterEndDateControl.valueChanges.subscribe(() => this.applyFiltersAndSorting());
    this.dateSortOrderControl.valueChanges.subscribe(() => this.applyFiltersAndSorting());

    this.facade.load();
  }

  applyFiltersAndSorting(): void {
    let processedAnalyses = [...this.allAnalyses];

    const filterType = this.filterTypeControl.value?.value;
    const filterStartDate = this.filterStartDateControl.value;
    const filterEndDate = this.filterEndDateControl.value;
    const dateSortOrder = this.dateSortOrderControl.value?.value;

    if (filterType !== 'all') {
      processedAnalyses = processedAnalyses.filter(
        (a) => a.tipo === filterType
      );
    }

    if (filterStartDate) {
      const startDate = new Date(filterStartDate);
      startDate.setMinutes(startDate.getMinutes() + startDate.getTimezoneOffset());

      processedAnalyses = processedAnalyses.filter(
        (a) => new Date(a.dataAnalise) >= startDate
      );
    }

    if (filterEndDate) {
      const endDate = new Date(filterEndDate);
      endDate.setMinutes(endDate.getMinutes() + endDate.getTimezoneOffset());
      endDate.setHours(23, 59, 59, 999);

      processedAnalyses = processedAnalyses.filter(
        (a) => new Date(a.dataAnalise) <= endDate
      );
    }

    processedAnalyses.sort((a, b) => {
      const dataA = new Date(a.dataAnalise).getTime();
      const dataB = new Date(b.dataAnalise).getTime();

      return dateSortOrder === 'recent' ? dataB - dataA : dataA - dataB;
    });

    this.filteredAnalyses = processedAnalyses;
  }

  refresh() {
    this.facade.load();
  }

  async downloadFile(blob: Blob, filename: string) {
    const blobUrl = window.URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = blobUrl;
    a.download = filename;
    a.click();
    window.URL.revokeObjectURL(blobUrl);
  }
}