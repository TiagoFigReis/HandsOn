import { Component, Input, ChangeDetectorRef, OnInit, OnChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';
import { descendingValuesValidator, FertilizerTable, NutrientHeaders, SoilFertilizerColumn, SoilFertilizerRow } from '@farm/core';
import { FieldsetComponent } from '../../../../components/fieldset/fieldset.component';

@Component({
  selector: 'lib-fertilizer-table-soil-form',
  imports: [CommonModule, ReactiveFormsModule, InputNumberComponent, FieldsetComponent],
  templateUrl: './fertilizer-table-soil-form.component.html',
  styleUrl: './fertilizer-table-soil-form.component.css',
})
export class FertilizerTableSoilFormComponent implements OnInit, OnChanges {
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
    private parentFormGroup: FormGroupDirective,
    private cdr: ChangeDetectorRef
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
    const row = this.soilRows.at(rowIndex);
    const groupControl = row.get(group);
    
    if (!groupControl) {
      return new FormControl(null);
    }
    
    return groupControl.get(`value${colIndex}`) as FormControl;
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
    const controlNames: string[] = [];

    for (let i = 1; i <= numberOfValues; i++) {
      const key = `value${i}`;
      const columnValue = column ? column[key as keyof SoilFertilizerColumn] as number : 1;

      controlNames.push(key);

      columnGroup[key] = this.formBuilder.control(columnValue, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      });
    }

    return this.formBuilder.group(columnGroup, {
      validators: descendingValuesValidator(controlNames)
    });
  }

  updateFertilizerTableData(): void {
    if (!this.fertilizerTable) return;

    while (this.soilRows.length)
      this.soilRows.removeAt(0);
    
    const columnKeys = ['n', 'p', 'k', 'b'];

    this.fertilizerTable.soilFertilizerRows.forEach((row, rowIndex) => {
      const rowFormGroup = this.formBuilder.group({});

      row.soilFertilizerColumns.forEach((column, colIndex) => {
        const key = columnKeys[colIndex];
        
        if (key === 'b' && rowIndex !== 0) {
          return;
        }
        
        rowFormGroup.addControl(
          key,
          this.createSoilColumn(column.numberOfValues, column)
        );
      });

      this.soilRows.push(rowFormGroup);
    });

    // Força detecção de mudanças
    this.cdr.detectChanges();
  }

  onSubmit(formValue: any, headerValues: any): SoilFertilizerRow[] {
    const soilRows: SoilFertilizerRow[] = formValue.soilRows.map((soilRow: any, rowIndex: number) => {
      const soilFertilizerColumns: SoilFertilizerColumn[] = [];

      const productivityString = this.soilRowsProductivities[rowIndex];
      const parts = productivityString.split('-');
      const expectedProductivity = parts.length > 1 ? Number(parts[1].trim()) : Number(parts[0].trim())

      // Nitrogênio
      soilFertilizerColumns.push({
        header: headerValues.indexOf(NutrientHeaders.N),
        numberOfValues: 2,
        value1: soilRow.n.value1,
        value2: soilRow.n.value2,
        value3: 0,
        value4: 0
      });
      
      // Fósforo
      soilFertilizerColumns.push({
        header: headerValues.indexOf(NutrientHeaders.P),
        numberOfValues: 3,
        value1: soilRow.p.value1,
        value2: soilRow.p.value2,
        value3: soilRow.p.value3,
        value4: 0
      });
      
      // Potássio
      soilFertilizerColumns.push({
        header: headerValues.indexOf(NutrientHeaders.K),
        numberOfValues: 4,
        value1: soilRow.k.value1,
        value2: soilRow.k.value2,
        value3: soilRow.k.value3,
        value4: soilRow.k.value4
      });

      // Boro
      if (rowIndex === 0 && soilRow.b) {
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