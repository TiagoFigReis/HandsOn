import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { minMedMaxValidator, NutrientRow, NutrientTable } from '@farm/core';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';

@Component({
  selector: 'lib-nutrient-table-soil-form',
  imports: [CommonModule, ReactiveFormsModule, InputNumberComponent],
  templateUrl: './nutrient-table-soil-form.component.html',
  styleUrl: './nutrient-table-soil-form.component.css',
})
export class NutrientTableSoilFormComponent {
  @Input() loading = false;
  @Input() nutrientTable?: NutrientTable | null;

  parentForm!: FormGroup
  soilRow: FormGroup

  soilHeaders = [
    {
      title: "Macronutrientes",
      items: [
        { label: 'P', complex: false, id: 0, inverted: false },
        { label: 'K', complex: false, id: 1, inverted: false },
        { label: 'Ca', complex: false, id: 2, inverted: false },
        { label: 'Mg', complex: false, id: 3, inverted: false },
        { label: 'S', complex: false, id: 4, inverted: false }
      ]
    },
    {
      title: 'Micronutrientes',
      items: [
        { label: 'Zn', complex: false, id: 5, inverted: false },
        { label: 'B', complex: false, id: 6, inverted: false },
        { label: 'Cu', complex: false, id: 7, inverted: false },
        { label: 'Mn', complex: false, id: 8, inverted: false },
        { label: 'Fe', complex: false, id: 9, inverted: false }
      ]
    },
    {
      title: 'Fertilidade',
      items: [
        { label: 'Matéria Orgânica', complex: false, id: 10, inverted: false },
        { label: 'Soma de Bases', complex: true, id: 11, inverted: false },
        { label: 'CTC', complex: true, id: 12, inverted: false },
        { label: 'Sat. por Bases', complex: true, id: 13, inverted: false }
      ]
    },
    {
      title: "Acidez",
      items: [
        { label: 'pH em Água', complex: false, id: 14, inverted: false },
        { label: 'Saturação por Al', complex: true, id: 15, inverted: true },
        { label: 'Acidez Potencial', complex: true, id: 16, inverted: true }
      ]
    }
  ];

  constructor(
    private formBuilder: FormBuilder,
    private parentFormGroup: FormGroupDirective
  ) {
    this.soilRow = formBuilder.group({
      soilColumns: this.formBuilder.array([])
    })
  }

  ngOnInit() {
    this.parentForm = this.parentFormGroup.control;

    this.parentForm.addControl('soilRow', this.soilRow);

    this.createSoilSection();

    if (this.nutrientTable) this.updateNutrientTableData();
  }

  ngOnChanges() {
    if (this.nutrientTable) this.updateNutrientTableData();
  }

  getSoilColumns(): FormArray {
    return this.soilRow.get('soilColumns') as FormArray;
  }
  getMinSoil(colIndex: number): FormControl {
    return this.getSoilColumns().at(colIndex).get('min') as FormControl;
  }
  getMaxSoil(colIndex: number): FormControl {
    return this.getSoilColumns().at(colIndex).get('max') as FormControl;
  }
  getMed1Soil(colIndex: number) {
    return this.getSoilColumns().at(colIndex).get('med1') as FormControl;
  }
  getMed2Soil(colIndex: number) {
    return this.getSoilColumns().at(colIndex).get('med2') as FormControl;
  }

  createSoilSection(): void {
    const allItems = this.soilHeaders.flatMap(header => header.items);

    allItems.forEach(item => {
      this.getSoilColumns().push(this.createSoilColumn(item.complex));
    });
  }
  createSoilColumn(complex: boolean, data?: { min: number, med1: number, med2: number, max: number }): FormGroup {
    return this.formBuilder.group({
      min: this.formBuilder.control(data?.min ?? 1, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      med1: this.formBuilder.control(complex ? data?.med1 ?? 2 : 0, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      med2: this.formBuilder.control(complex ? data?.med2 ?? 3 : 0, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      max: this.formBuilder.control(data?.max ?? 4, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
    }, { validators: minMedMaxValidator(complex) });
  }

  updateNutrientTableData(): void {
    if (!this.nutrientTable) return;

    while (this.getSoilColumns().length)
      this.getSoilColumns().removeAt(0);

    this.nutrientTable.soilNutrientRow.nutrientColumns.forEach((column) => {
      const complex = column.med1 !== 0 && column.med2 !== 0;

      const columnFormGroup = this.createSoilColumn(complex, column);

      this.getSoilColumns().push(columnFormGroup);
    })
  }

  onSubmit(formValue: any, headerValues: any): NutrientRow {
    const allItems = this.soilHeaders.flatMap(header => header.items);

    const soilRow: NutrientRow = {
      nutrientColumns: formValue.soilRow.soilColumns.map((soilColumn: any, colIndex: number) => {
        const item = allItems[colIndex];

        const cleanHeader = item.label.split("<br>")[0].trim();
        const header = headerValues.indexOf(cleanHeader);

        return {
          header: header,
          inverted: item.inverted,
          min: soilColumn.min,
          med1: soilColumn.med1,
          med2: soilColumn.med2,
          max: soilColumn.max
        };
      })
    };

    return soilRow;
  }
}
