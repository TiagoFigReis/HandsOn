import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormControl, ReactiveFormsModule } from '@angular/forms';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';
import { FieldsetComponent } from '../../../../components/fieldset/fieldset.component';

interface LeafHeaderItem {
  label: string;
  id: number;
}

export interface LeafHeaderGroup {
  title: string;
  items: LeafHeaderItem[];
}

@Component({
  selector: 'lib-nutrient-table-leaf-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InputNumberComponent,
    FieldsetComponent
  ],
  templateUrl: './nutrient-table-leaf-form.component.html',
  styleUrl: './nutrient-table-leaf-form.component.css',
})
export class NutrientTableLeafFormComponent {
  @Input() leafRows!: FormArray;
  @Input() periods!: string[];
  @Input() leafHeaders!: LeafHeaderGroup[]; 

  selectedPeriodIndex = 0;

  getLeafColumns(rowIndex: number): FormArray {
    return this.leafRows.at(rowIndex).get('leafColumns') as FormArray;
  }
  getMinLeaf(rowIndex: number, columnIndex: number): FormControl {
    return this.getLeafColumns(rowIndex).at(columnIndex).get('min') as FormControl;
  }
  getMaxLeaf(rowIndex: number, columnIndex: number): FormControl {
    return this.getLeafColumns(rowIndex).at(columnIndex).get('max') as FormControl;
  }

  selectPeriod(index: number) {
    this.selectedPeriodIndex = index;
  }
}