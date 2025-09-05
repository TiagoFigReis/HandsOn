import {
  AfterViewInit,
  Component,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { debounceTime } from 'rxjs';
import { Table, TableFilterEvent, TableModule } from 'primeng/table';
import { Skeleton } from 'primeng/skeleton';
import { ButtonComponent, Column, ColumnWidths, InputComponent, Row } from '../../../';
import { ConfirmationService, FilterMetadata } from 'primeng/api';
import {
  Action,
  ActionButtonComponent,
} from '../table/lib/action-button/action-button.component';
import { Culture } from '@farm/core';
import { InputCultureComponent } from './lib/input-culture/input-culture.component';

@Component({
  selector: 'lib-table-cultures',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TableModule,
    Skeleton,
    ButtonComponent,
    InputCultureComponent,
    InputComponent,
    ActionButtonComponent,
  ],
  templateUrl: './table-cultures.component.html',
  styleUrl: './table-cultures.component.css',
})
export class TableCulturesComponent implements AfterViewInit, OnInit {
  @Input() data: Row[] = [];
  @Input() columns: Column[] = [];
  @Input() loading = false;
  @Input() showLoader = false;
  @Input() totalRecords = 0;
  @Input() rows = 10;
  @Input() rowsPerPageOptions: number[] = [10, 25, 50, 100];
  @Input() paginator = true;
  @Input() stateKey = 'tableState';
  @Input() globalFilterFields: string[] = [];
  @Input() dataKey = 'id';
  @Input() currencyCode: 'BRL' | 'USD' | 'EUR' = 'BRL';
  @Input() showMoreButton = false;

  @Output() rowSelect: EventEmitter<Row> = new EventEmitter();
  @Output() rowUnselect: EventEmitter<Row> = new EventEmitter();
  @Output() refresh: EventEmitter<void> = new EventEmitter();

  @ViewChild(Table) table: Table | undefined;

  @Input() culture: Culture | undefined;
  @Input() submitLabel = 'Cadastrar Cultura';

  @Output() cultureSubmit = new EventEmitter<Culture>();

  selectedData: Row[] = [];
  showClearFilterButton = false;
  searchControl = new FormControl('');
  filteredColumns: Column[] = [];

  columnsWidths: ColumnWidths = {};
  totalColumnsWidth = 0;

  cultureForm: FormGroup;

  constructor() {
    this.cultureForm = new FormGroup({
      name: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
        updateOn: 'blur',
      })
    });
  }

  ngOnInit() {
    this.searchControl.valueChanges
      .pipe(debounceTime(300))
      .subscribe((term) => {
        this.onFilterGlobal(term);
      });

    this.filteredColumns = this.columns.filter(
      (column) => column.showToUser && column.visible,
    );

    this.calculateColumnsWidths();
  }

  ngAfterViewInit() {
    this.globalFilterFields = this.columns
      .filter((column) => column.showToUser)
      .map((column) => column.field);

    const state = localStorage.getItem(this.stateKey);

    if (state) {
      const parsedState = JSON.parse(state);

      if (parsedState.filters) {
        this.onFilterGlobal(parsedState.filters.global?.value);
      }
    }
  }

  get name(): FormControl {
    return this.cultureForm.get('name') as FormControl;
  }

  onRowSelected(event: any) {
    this.rowSelect.emit(event);
  }

  onRowUnselected(event: any) {
    this.rowUnselect.emit(event);
  }

  clearSelection() {
    this.selectedData = [];
  }

  get getSelectedData(): Row[] {
    return this.selectedData;
  }

  get getColumns(): Column[] {
    return this.columns.filter((column) => column.visible);
  }

  get getGlobalFilterFields(): string[] {
    return this.globalFilterFields;
  }

  onFilter(event: TableFilterEvent) {
    if (!event.filters || !this.table) return;

    const filters = event.filters;

    this.showClearFilterButton = Object.keys(filters).some((key) => {
      if (!event.filters || !event.filters[key]) return false;
      if (key === 'global' && event.filters[key].value) return true;

      const column = this.columns.find((column) => column.field === key);
      if (!column) return false;

      return (event.filters[key] as FilterMetadata[]).some((filter) => {
        if (filter.value) return true;

        return false;
      });
    });
  }

  onFilterGlobal(term: string | null) {
    if (!this.table) return;

    if (term && term.length > 0) {
      this.showClearFilterButton = true;
      this.table.filterGlobal(term, 'contains');
    } else {
      this.showClearFilterButton = false;
      this.table.clear();
      this.table.reset();
      this.table.clearFilterValues();
      this.table.clearState();
    }
  }

  onClearFilter() {
    if (!this.table) return;

    this.searchControl.setValue('');
    this.showClearFilterButton = false;
    this.table.clear();
    this.table.reset();
    this.table.clearFilterValues();
    this.table.clearState();
  }

  onExport() {
    if (!this.table) return;

    this.table.exportCSV({
      allValues: true,
    });
  }

  onRefresh() {
    this.refresh.emit();
  }

  onSubmit() {
    if (this.cultureForm.invalid) {
      return this.cultureForm.markAllAsTouched();
    }

    const formValue = this.cultureForm.value;

    const culture: Culture = {
      id: this.culture?.id,
      name: formValue.name
    }

    this.cultureSubmit.emit(culture);
  }

  calculateColumnsWidths() {
    this.totalColumnsWidth = 0;

    const columnsWidths = this.columns
      .filter((column) => column.showToUser && column.visible)
      .reduce(
        (
          acc: {
            [key: string]: number;
          },
          column: Column,
        ) => {
          const fraction = column.fraction || 1;

          this.totalColumnsWidth += fraction;

          acc[column.field] = fraction;

          return acc;
        },
        {},
      );

    const size = this.showMoreButton ? 95 : 100;

    this.columnsWidths = Object.keys(columnsWidths).reduce(
      (
        acc: {
          [key: string]: string;
        },
        key: string,
      ) => {
        const value: number =
          (columnsWidths[key] / this.totalColumnsWidth) * size;

        acc[key] = `${value.toFixed(2)}%`;

        return acc;
      },
      {},
    );
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

export { Action };
