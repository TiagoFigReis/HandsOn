import { Component, Input, ChangeDetectorRef, NgZone, OnInit, OnChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputComponent } from '../../../../components/input/input.component';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';
import { ButtonComponent } from '../../../../components/button/button.component';
import { CheckboxComponent } from '../../../../components/checkbox/checkbox.component';
import { FertilizerTable, LeafFertilizerProduct, LeafFertilizerRow, minMaxValidator, NutrientHeaders } from '@farm/core';

@Component({
  selector: 'lib-fertilizer-table-leaf-form',
  imports: [
    CommonModule,
    InputComponent,
    ReactiveFormsModule,
    InputNumberComponent,
    ButtonComponent,
    CheckboxComponent,
  ],
  templateUrl: './fertilizer-table-leaf-form.component.html',
  styleUrl: './fertilizer-table-leaf-form.component.css',
})
export class FertilizerTableLeafFormComponent implements OnInit, OnChanges {
  @Input() loading = false;
  @Input() fertilizerTable?: FertilizerTable | null;;

  parentForm!: FormGroup
  leafRow: FormGroup
  macroHeaders = [
    {
      label: 'Nitrogênio (N)',
      products: [],
      key: NutrientHeaders.N
    }, {
      label: 'Fósforo (P)',
      products: [],
      key: NutrientHeaders.P
    }, {
      label: 'Potássio (K)',
      products: [],
      key: NutrientHeaders.K
    }, {
      label: 'Cálcio (Ca)',
      products: [],
      key: NutrientHeaders.Ca
    }, {
      label: 'Magnésio (Mg)',
      products: [],
      key: NutrientHeaders.Mg
    }, {
      label: 'Enxofre (S)',
      products: [],
      key: NutrientHeaders.S
    }
  ];

  microHeaders = [
    {
      label: 'Zinco (Zn)',
      products: [],
      key: NutrientHeaders.Zn
    }, {
      label: 'Boro (B)',
      products: [],
      key: NutrientHeaders.B
    }, {
      label: 'Cobre (Cu)',
      products: [],
      key: NutrientHeaders.Cu
    }, {
      label: 'Manganês (Mn)',
      products: [],
      key: NutrientHeaders.Mn
    }, {
      label: 'Ferro (Fe)',
      products: [],
      key: NutrientHeaders.Fe
    }
  ];

  headerGroups: { 
    title: string, 
    headers: { header: any, columnIndex: number }[] 
  }[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private parentFormGroup: FormGroupDirective,
    private cdr: ChangeDetectorRef,
    private zone: NgZone
  ) {
    this.leafRow = formBuilder.group({
      leafColumns: formBuilder.array([])
    });
  }

  ngOnInit() {
    this.parentForm = this.parentFormGroup.control;
    this.parentForm.addControl('leafRow', this.leafRow);
    this.createLeafSection();

    if (this.fertilizerTable) this.updateFertilizerTableData();

    this.buildHeaderGroups();
  }

  ngOnChanges() {
    if (this.fertilizerTable) this.updateFertilizerTableData();
  }

  buildHeaderGroups() {
    const macroItems = this.macroHeaders.map((header, index) => ({
      header: header,
      columnIndex: index 
    }));

    const microItems = this.microHeaders.map((header, index) => ({
      header: header,
      columnIndex: index + this.macroHeaders.length 
    }));

    this.headerGroups = [
      { title: 'Macronutrientes', headers: macroItems },
      { title: 'Micronutrientes', headers: microItems }
    ];
  }

  getLeafColumns(): FormArray {
    return this.leafRow.get('leafColumns') as FormArray;
  }
  getLeafColumn(index: number): FormGroup {
    return this.getLeafColumns().at(index) as FormGroup;
  }
  getProducts(columnIndex: number): FormArray {
    return this.getLeafColumn(columnIndex).get('products') as FormArray;
  }
  getProduct(columnIndex: number, productIndex: number): FormGroup {
    return this.getProducts(columnIndex).at(productIndex) as FormGroup;
  }
  getName(columnIndex: number, productIndex: number): FormControl {
    return this.getProduct(columnIndex, productIndex).get('name') as FormControl;
  }
  getMin(columnIndex: number, productIndex: number): FormControl {
    return this.getProduct(columnIndex, productIndex).get('min') as FormControl;
  }
  getMax(columnIndex: number, productIndex: number): FormControl {
    return this.getProduct(columnIndex, productIndex).get('max') as FormControl;
  }
  getSolid(columnIndex: number, productIndex: number): FormControl {
    return this.getProduct(columnIndex, productIndex).get('solid') as FormControl;
  }
  
  public getProdControl(productControl: AbstractControl, controlName: string): FormControl {
    return productControl.get(controlName) as FormControl;
  }

  createLeafSection(): void {
    for (let i = 0; i < this.macroHeaders.length; i++)
      this.getLeafColumns().push(this.createLeafColumn());

    for (let i = 0; i < this.microHeaders.length; i++)
      this.getLeafColumns().push(this.createLeafColumn());
  }
  createLeafColumn(): FormGroup {
    return this.formBuilder.group({
      products: this.formBuilder.array([])
    });
  }
  createLeafProduct(data?: { name: string, min: number, max: number, solid: boolean }): FormGroup {
    return this.formBuilder.group({
      name: this.formBuilder.control(data?.name ?? '', {
        validators: [Validators.required],
        updateOn: 'blur'
      }),
      min: this.formBuilder.control(data?.min ?? null, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      max: this.formBuilder.control(data?.max ?? null, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      solid: this.formBuilder.control(data?.solid ?? false, {
        validators: [Validators.required]
      }),
    }, { validators: minMaxValidator('min', 'max') });
  }

  private _addProduct(columnIndex: number, data?: { name: string, min: number, max: number, solid: boolean }): FormGroup {
    const productGroup = this.createLeafProduct(data);
    this.getProducts(columnIndex).push(productGroup);
    return productGroup;
  }

  addProduct(header: any, columnIndex: number, data?: { name: string, min: number, max: number, solid: boolean }): void {
    this.zone.run(() => {
      this._addProduct(columnIndex, data);
      this.cdr.detectChanges();
    });
  }

  removeProduct(header: any, columnIndex: number, productIndex: number): void {
    this.zone.run(() => {
      this.getProducts(columnIndex).removeAt(productIndex);
      this.cdr.detectChanges();
    });
  }

  updateFertilizerTableData(): void {
    if (!this.fertilizerTable) return;

    this.fertilizerTable.leafFertilizerRow.leafFertilizerColumns.forEach((column, colIndex) => {
      let header: any;

      if (colIndex < this.macroHeaders.length)
        header = this.macroHeaders[colIndex];
      else
        header = this.microHeaders[colIndex - this.macroHeaders.length];

      if (header) {
        column.products.forEach((product) => {
          this._addProduct(colIndex, { name: product.name, min: product.minConcentration, max: product.maxConcentration, solid: product.solid });
        });
      }
    });
    
    this.cdr.detectChanges();
  }

  onSubmit(formValue: any, headerValues: any): LeafFertilizerRow {
    const leafHeaders = [...this.macroHeaders, ...this.microHeaders];

    const leafRow: LeafFertilizerRow = {
      leafFertilizerColumns: formValue.leafRow.leafColumns.map((leafColumn: any, colIndex: number) => {
        const products: LeafFertilizerProduct[] = leafColumn.products.map((product: any) => {
          return {
            name: product.name,
            solid: product.solid,
            minConcentration: product.min,
            maxConcentration: product.max
          };
        });

        return {
          header: headerValues.indexOf(leafHeaders[colIndex].key),
          products: products
        };
      })
    };

    return leafRow;
  }

  calculateMicroColIndex(microIndex: number): number {
    return microIndex + this.macroHeaders.length;
  }
}