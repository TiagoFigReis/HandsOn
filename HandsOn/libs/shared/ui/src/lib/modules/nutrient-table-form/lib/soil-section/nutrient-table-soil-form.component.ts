import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';
import { FieldsetComponent } from '../../../../components/fieldset/fieldset.component';

@Component({
  selector: 'lib-nutrient-table-soil-form',
  imports: [CommonModule, ReactiveFormsModule, InputNumberComponent, FieldsetComponent],
  templateUrl: './nutrient-table-soil-form.component.html',
  styleUrl: './nutrient-table-soil-form.component.css',
})
export class NutrientTableSoilFormComponent {
  @Input() soilRow!: FormGroup;
  @Input() soilHeaders!: any[];

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
}

