import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormArray, FormBuilder, FormControl, FormGroup, FormGroupDirective, ReactiveFormsModule, Validators } from '@angular/forms';
import { InputComponent } from '../../../../components/input/input.component';
import { InputNumberComponent } from '../../../../components/input-number/input-number.component';
import { ButtonComponent } from '../../../../components/button/button.component';
import { CheckboxComponent } from '../../../../components/checkbox/checkbox.component';
import { DividerComponent } from '../../../../components/divider/divider.component';
import { FertilizerTable, LeafFertilizerProduct, LeafFertilizerRow, minMaxValidator, SoilFertilizerRow } from '@farm/core';

@Component({
  selector: 'lib-fertilizer-table-leaf-form',
  imports: [
    CommonModule,
    InputComponent,
    ReactiveFormsModule,
    InputNumberComponent,
    ButtonComponent,
    CheckboxComponent,
    DividerComponent
  ],
  templateUrl: './fertilizer-table-leaf-form.component.html',
  styleUrl: './fertilizer-table-leaf-form.component.css',
})
export class FertilizerTableLeafFormComponent {
  @Input() loading = false;
  @Input() fertilizerTable?: FertilizerTable | null;;

  parentForm!: FormGroup
  leafRow: FormGroup
  macroHeaders = [
    {
      label: 'N',
      products: []
    }, {
      label: 'P',
      products: []
    }, {
      label: 'K',
      products: []
    }, {
      label: 'Ca',
      products: []
    }, {
      label: 'Mg',
      products: []
    }, {
      label: 'S',
      products: []
    }
  ];
  microHeaders = [
    {
      label: 'Zn',
      products: []
    }, {
      label: 'B',
      products: []
    }, {
      label: 'Cu',
      products: []
    }, {
      label: 'Mn',
      products: []
    }, {
      label: 'Fe',
      products: []
    }, {
      label: 'Mb',
      products: []
    },
  ];

  constructor(
    private formBuilder: FormBuilder,
    private parentFormGroup: FormGroupDirective
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
  }

  ngOnChanges() {
    if (this.fertilizerTable) this.updateFertilizerTableData();
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
        validators: [Validators.required],
        updateOn: 'blur'
      }),
    }, { validators: minMaxValidator('min', 'max') });
  }
  addProduct(header: any, columnIndex: number, data?: { name: string, min: number, max: number, solid: boolean }): FormGroup {
    header.products.push({ name: '', min: '', max: '' });

    const productGroup = this.createLeafProduct(data);

    this.getProducts(columnIndex).push(productGroup);

    return productGroup;
  }
  removeProduct(header: any, columnIndex: number, productIndex: number): void {
    header.products.splice(productIndex, 1);

    this.getProducts(columnIndex).removeAt(productIndex);
  }

  updateFertilizerTableData(): void {
    if (!this.fertilizerTable) return;

    this.fertilizerTable.leafFertilizerRow.leafFertilizerColumns.forEach((column, colIndex) => {
      let header: any;

      if (colIndex < this.macroHeaders.length)
        header = this.macroHeaders[colIndex];
      else
        header = this.microHeaders[colIndex - this.macroHeaders.length];

      column.products.forEach((product) => {
        this.addProduct(header, colIndex, { name: product.name, min: product.minConcentration, max: product.maxConcentration, solid: product.solid });
      });
    });
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
          header: headerValues.indexOf(leafHeaders[colIndex].label),
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