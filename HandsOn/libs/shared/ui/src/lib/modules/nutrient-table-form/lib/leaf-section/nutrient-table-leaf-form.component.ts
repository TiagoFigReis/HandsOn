import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { minMaxValidator, NutrientColumn, NutrientRow, NutrientTable } from '@farm/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';

@Component({
  selector: 'lib-nutrient-table-leaf-form',
  imports: [CommonModule, ReactiveFormsModule, InputNumberComponent],
  templateUrl: './nutrient-table-leaf-form.component.html',
  styleUrl: './nutrient-table-leaf-form.component.css',
})
export class NutrientTableLeafFormComponent {
  @Input() loading = false;
  @Input() nutrientTable?: NutrientTable | null;

  parentForm!: FormGroup
  leafRows: FormArray;
  leafHeaders = [
    'N',
    'P',
    'K',
    'Ca',
    'Mg',
    'S',
    'Zn',
    'B',
    'Cu',
    'Mn',
    'Fe',
    'N/P',
    'N/K',
    'N/S',
    'N/B',
    'N/Cu',
    'P/Mg',
    'P/Zn',
    'K/Ca',
    'K/Mg',
    'K/Mn',
    'Ca/Mg',
    'Ca/Mn',
    'Fe/Mn'
  ];
  periods: string[] = []

  constructor(
    private formBuilder: FormBuilder,
    private parentFormGroup: FormGroupDirective
  ) {
    this.leafRows = formBuilder.array([])
  }

  ngOnInit() {
    this.parentForm = this.parentFormGroup.control;

    this.parentForm.addControl('leafRows', this.leafRows);

    if (this.nutrientTable) this.updateNutrientTableData();
  }

  ngOnChanges() {
    if (this.nutrientTable) this.updateNutrientTableData();
  }

  getLeafColumns(rowIndex: number): FormArray {
    return this.leafRows.at(rowIndex).get('leafColumns') as FormArray;
  }
  getMinLeaf(rowIndex: number, columnIndex: number): FormControl {
    return this.getLeafColumns(rowIndex).at(columnIndex).get('min') as FormControl;
  }
  getMaxLeaf(rowIndex: number, columnIndex: number): FormControl {
    return this.getLeafColumns(rowIndex).at(columnIndex).get('max') as FormControl;
  }

  createLeafRow(): FormGroup {
    return this.formBuilder.group({
      leafColumns: this.formBuilder.array(
        Array.from({ length: this.leafHeaders.length }, () => this.createLeafColumn())
      )
    });
  }
  createLeafColumn(data?: { min: number, max: number }): FormGroup {
    return this.formBuilder.group({
      min: this.formBuilder.control(data?.min ?? null, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      max: this.formBuilder.control(data?.max ?? null, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
    }, {validators: minMaxValidator('min', 'max')});
  }

  setRowsBasedOnDivision(value: string): void {
    const rowsFormArray = this.leafRows;
    while (rowsFormArray.length > 1)
      rowsFormArray.removeAt(1);

    let numberOfRows = 1;

    switch (value) {
      case '0':
        numberOfRows = 1;
        this.setPeriods(value);
        break;
      case '1':
        numberOfRows = 2;
        this.setPeriods(value);
        break;
      case '2':
        numberOfRows = 4
        this.setPeriods(value);
        break;
      case '3':
        numberOfRows = 6
        this.setPeriods(value);
    }

    let currentLength = rowsFormArray.length;

    for (let i = 0; i < numberOfRows - currentLength; i++)
      rowsFormArray.push(this.createLeafRow());
  }
  setPeriods(value: string): void {
    switch (value) {
      case '0':
        this.periods = ["Anual"];
        break;
      case '1':
        this.periods = ["Jan-Jun", "Jul-Dez"];
        break;
      case '2':
        this.periods = ["Jan-Mar", "Abr-Jun", "Jul-Set", "Out-Dez"]
        break;
      case '3':
        this.periods = ["Jan/Fev", "Mar/Abr", "Mai/Jun", "Jul/Ago", "Set/Out", "Nov/Dez"]
    }
  }

  updateNutrientTableData() {
    if (!this.nutrientTable) return;;

    while (this.leafRows.length)
      this.leafRows.removeAt(0);

    this.nutrientTable.leafNutrientRows.forEach((row) => {
      const columnsFormArray = this.formBuilder.array(
        row.nutrientColumns.map(column =>
          this.createLeafColumn({
            min: column.min,
            max: column.max
          })
        )
      );

      const rowFormGroup = this.formBuilder.group({
        leafColumns: columnsFormArray
      });

      this.leafRows.push(rowFormGroup);
    })
  }

  onSubmit(formValue: any): NutrientRow[] {
    const leafRows: NutrientRow[] = formValue.leafRows.map((leafRow: any, rowIndex: number) => {
      const nutrientColumns: NutrientColumn[] = leafRow.leafColumns.map((leafColumn: any, colIndex: number) => ({
        header: colIndex,
        min: leafColumn.min,
        max: leafColumn.max,
      }));

      return {
        nutrientColumns
      };
    });

    return leafRows;
  }
}