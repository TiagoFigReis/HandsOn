import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';
import { FertilizerTable, NutrientHeaders, SoilFertilizerColumn, SoilFertilizerRow } from '@farm/core';

@Component({
  selector: 'lib-fertilizer-table-soil-form',
  imports: [CommonModule, ReactiveFormsModule, InputNumberComponent],
  templateUrl: './fertilizer-table-soil-form.component.html',
  styleUrl: './fertilizer-table-soil-form.component.css',
})
export class FertilizerTableSoilFormComponent {
  @Input() loading = false;
  @Input() fertilizerTable?: FertilizerTable | null;

  parentForm!: FormGroup
  soilRows: FormArray
  soilRowsProductivities = [
    "2",
    "2-4",
    "4-6",
    "6-8",
    "8-10",
    "10-12",
    "12-14",
    "14-16",
    "16-18",
    "18-20"
  ];

  constructor(
    private formBuilder: FormBuilder,
    private parentFormGroup: FormGroupDirective
  ) {
    this.soilRows = formBuilder.array([])
  }

  ngOnInit() {
    this.parentForm = this.parentFormGroup.control;

    this.parentForm.addControl('soilRows', this.soilRows);

    this.createSoilSection();

    if (this.fertilizerTable) this.updateFertilizerTableData();
  }

  ngOnChanges() {
    if (this.fertilizerTable) this.updateFertilizerTableData();
  }

  getValue(rowIndex: number, group: string, colIndex: number): FormControl {
    return this.soilRows.at(rowIndex).get(group)?.get(`value${colIndex}`) as FormControl;
  }

  createSoilSection(): void {
    for (let i = 0; i < this.soilRowsProductivities.length; i++)
      this.soilRows.push(this.createSoilRow(i == 0));
  }
  createSoilRow(hasB: boolean): FormGroup {
    const rowGroup: any = {
      n: this.createSoilColumn(2),
      p: this.createSoilColumn(3),
      k: this.createSoilColumn(4)
    };

    if (hasB)
      rowGroup.b = this.createSoilColumn(4);

    return this.formBuilder.group(rowGroup);
  }
  createSoilColumn(numberOfValues: number, column?: SoilFertilizerColumn): FormGroup {
    const columnGroup: { [key: string]: FormControl } = {};

    for (let i = 1; i <= numberOfValues; i++) {
      const key = `value${i}`;
      const columnValue = column ? column[key as keyof SoilFertilizerColumn] as number : null;

      columnGroup[key] = this.formBuilder.control(columnValue, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      });
    }

    return this.formBuilder.group(columnGroup);
  }

  updateFertilizerTableData(): void {
    if (!this.fertilizerTable) return;

    while (this.soilRows.length)
      this.soilRows.removeAt(0);
    
    const columnKeys = ['n', 'p', 'k', 'b'];

    this.fertilizerTable.soilFertilizerRows.forEach((row) => {
      const rowFormGroup = this.formBuilder.group({});

      row.soilFertilizerColumns.forEach((column, index) => {
        const key = columnKeys[index];
        rowFormGroup.addControl(
          key,
          this.createSoilColumn(column.numberOfValues, column)
        );
      });

      this.soilRows.push(rowFormGroup);
    });
  }

  onSubmit(formValue: any, headerValues: any): SoilFertilizerRow[] {
    const soilRows: SoilFertilizerRow[] = formValue.soilRows.map((soilRow: any, rowIndex: number) => {
      const soilFertilizerColumns: SoilFertilizerColumn[] = [];

      const productivityString = this.soilRowsProductivities[rowIndex];
      const parts = productivityString.split('-');
      const expectedProductivity = parts.length > 1 ? Number(parts[1].trim()) : Number(parts[0].trim())

      soilFertilizerColumns.push({
        header: headerValues.indexOf(NutrientHeaders.N),
        numberOfValues: 2,
        value1: soilRow.n.value1,
        value2: soilRow.n.value2,
        value3: 0,
        value4: 0
      });
      soilFertilizerColumns.push({
        header: headerValues.indexOf(NutrientHeaders.P),
        numberOfValues: 3,
        value1: soilRow.p.value1,
        value2: soilRow.p.value2,
        value3: soilRow.p.value3,
        value4: 0
      });
      soilFertilizerColumns.push({
        header: headerValues.indexOf(NutrientHeaders.K),
        numberOfValues: 4,
        value1: soilRow.k.value1,
        value2: soilRow.k.value2,
        value3: soilRow.k.value3,
        value4: soilRow.k.value4
      });

      if (rowIndex == 0) {
        soilFertilizerColumns.push({
          header: headerValues.indexOf(NutrientHeaders.B),
          numberOfValues: 4,
          value1: soilRow.b.value1,
          value2: soilRow.b.value2,
          value3: soilRow.b.value3,
          value4: soilRow.b.value4
        });
      }

      return {
        expectedProductivity: expectedProductivity,
        soilFertilizerColumns: soilFertilizerColumns
      };
    });

    return soilRows;
  }
}