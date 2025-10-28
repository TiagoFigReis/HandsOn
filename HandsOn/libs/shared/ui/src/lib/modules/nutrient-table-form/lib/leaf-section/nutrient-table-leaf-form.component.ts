import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormControl, ReactiveFormsModule } from '@angular/forms';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';

interface NutrientColumn {
  header: string;
  index: number;
}

interface NutrientGroup {
  title: string;
  items: NutrientColumn[];
}

@Component({
  selector: 'lib-nutrient-table-leaf-form',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    InputNumberComponent,
  ],
  templateUrl: './nutrient-table-leaf-form.component.html',
  styleUrl: './nutrient-table-leaf-form.component.css',
})
export class NutrientTableLeafFormComponent implements OnInit, OnChanges {
  @Input() leafRows!: FormArray;
  @Input() periods!: string[];
  @Input() leafHeaders!: string[];

  selectedPeriodIndex = 0;

  macroColumns: NutrientColumn[] = [];
  microColumns: NutrientColumn[] = [];
  relationColumns: NutrientColumn[] = [];

  nutrientGroups: NutrientGroup[] = [];

  private readonly MACRO_NUTRIENTS = [
  'Nitrogênio (N)',
  'Fósforo (P)',
  'Potássio (K)',
  'Cálcio (Ca)',
  'Magnésio (Mg)',
  'Enxofre (S)'
];

private readonly MICRO_NUTRIENTS = [
  'Zinco (Zn)',
  'Boro (B)',
  'Cobre (Cu)',
  'Manganês (Mn)',
  'Ferro (Fe)',
  'Molibdênio (Mb)'
];

  ngOnInit() {
    this.categorizeHeaders();
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['leafHeaders']) {
      this.categorizeHeaders();
    }
  }

  private categorizeHeaders() {
    if (!this.leafHeaders) return;

    this.macroColumns = [];
    this.microColumns = [];
    this.relationColumns = [];

    this.leafHeaders.forEach((header, index) => {
      const col = { header, index };
      if (this.MACRO_NUTRIENTS.includes(header)) {
        this.macroColumns.push(col);
      } else if (this.MICRO_NUTRIENTS.includes(header)) {
        this.microColumns.push(col);
      } else {
        this.relationColumns.push(col);
      }
    });

    this.nutrientGroups = []; 

    if (this.macroColumns.length > 0) {
      this.nutrientGroups.push({
        title: 'Macronutrientes',
        items: this.macroColumns,
      });
    }

    if (this.microColumns.length > 0) {
      this.nutrientGroups.push({
        title: 'Micronutrientes',
        items: this.microColumns,
      });
    }

    if (this.relationColumns.length > 0) {
      this.nutrientGroups.push({
        title: 'Relações',
        items: this.relationColumns,
      });
    }
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

  selectPeriod(index: number) {
    this.selectedPeriodIndex = index;
  }
}