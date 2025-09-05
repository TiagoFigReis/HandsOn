import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  FormBuilder,
  FormArray,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { ButtonComponent } from '../../components/button/button.component';
import {
  FertilizerTable,
  CultureFacade,
  Culture,
  User,
  NutrientHeaders,
  SoilFertilizerRow,
  SoilFertilizerColumn,
  LeafFertilizerRow,
  LeafFertilizerProduct
} from '@farm/core';
import { SelectComponent, SelectOption } from '../../components/select/select.component';
import { InputNutrientTableComponent } from '../../components/input-nutrient-table/input-nutrient-table.component';
import { CheckboxComponent } from '../../components/checkbox/checkbox.component';
import { InputComponent } from '../../components/input/input.component';

@Component({
  selector: 'lib-fertilizer-table-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonComponent,
    SelectComponent,
    InputComponent,
    CheckboxComponent,
    InputNutrientTableComponent
  ],
  templateUrl: './fertilizer-table-form.component.html',
  styleUrl: './fertilizer-table-form.component.css',
})
export class FertilizerTableFormComponent implements OnInit, OnChanges {
  @Input() fertilizerTable: FertilizerTable | undefined;
  @Input() user: User | undefined;
  @Input() loading = false;
  @Input() selectCulture = false;
  @Input() submitLabel = 'Cadastrar';

  @Output() fertilizerTableSubmit = new EventEmitter<FertilizerTable>();

  fertilizerTableForm: FormGroup;

  activeTable = 'leaf';
  cultureOptions: SelectOption[] = [];

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
  numberOfColumns = 9;

  leafHeaders = [
    {
      label: 'Zn',
      products: []
    },
    {
      label: 'Cu',
      products: []
    },
    {
      label: 'Mn',
      products: []
    },
    {
      label: 'Fe',
      products: []
    },
    {
      label: 'S',
      products: []
    }
  ];
  soilHeaders = [
    "N",
    "P",
    "K",
    "B"
  ];

  constructor(
    private formBuilder: FormBuilder,
    private cultureFacade: CultureFacade
  ) {
    this.fertilizerTableForm = this.formBuilder.group({
      cultureType: this.formBuilder.control('', {
        validators: [],
        updateOn: 'blur'
      }),
      expectedBasesSat: this.formBuilder.control('', {
        validators: [Validators.required],
        updateOn: 'blur'
      }),
      leafRow: this.formBuilder.group({
        leafColumns: this.formBuilder.array([])
      }),
      soilRows: this.formBuilder.array([])
    });
  }

  ngOnInit(): void {
    this.cultureFacade.getAllCulturesWithoutFertilizerTable().subscribe({
      next: (cultures: Culture[]) => {
        this.cultureOptions = cultures.map(c => ({
          value: c.id?.toString()!,
          label: c.name
        }));
      }
    });

    if (this.fertilizerTable) this.updateFertilizerTableData();

    this.createLeafSection();
    this.createSoilSection();

    if (this.selectCulture) this.cultureType.setValidators([Validators.required]);
  }

  ngOnChanges(): void {
    if (this.fertilizerTable) this.updateFertilizerTableData();

    if (this.loading) this.fertilizerTableForm.disable();
    else this.fertilizerTableForm.enable();
  }

  get cultureType(): FormControl {
    return this.fertilizerTableForm.get('cultureType') as FormControl;
  }
  get expectedBasesSat(): FormControl {
    return this.fertilizerTableForm.get('expectedBasesSat') as FormControl;
  } 

  get leafRow(): FormGroup {
    return this.fertilizerTableForm.get('leafRow') as FormGroup;
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

  get soilRows(): FormArray {
    return this.fertilizerTableForm.get('soilRows') as FormArray;
  }
  getValue(rowIndex: number, group: string, colIndex: number): FormControl {
    return this.soilRows.at(rowIndex).get(group)?.get(`value${colIndex}`) as FormControl;
  }

  updateFertilizerTableData(): void {
    if (!this.fertilizerTable) return;

    this.fertilizerTableForm.patchValue({
      cultureType: { value: this.fertilizerTable.cultureId },
      expectedBasesSat: { value: this.fertilizerTable.expectedBasesSaturation }
    });
  }

  setLeafSection(): void {
    this.activeTable = 'leaf';
  }
  setSoilSection(): void {
    this.activeTable = 'soil';
  }

  createLeafSection(): void {
    for (let i = 0; i < this.leafHeaders.length; i++)
      this.getLeafColumns().push(this.createLeafColumn());
  }
  createLeafColumn(): FormGroup {
    return this.formBuilder.group({
      products: this.formBuilder.array([])
    });
  }
  createLeafProduct(): FormGroup {
    return this.formBuilder.group({
      name: this.formBuilder.control('', {
        validators: [Validators.required],
        updateOn: 'blur'
      }),
      min: this.formBuilder.control('', {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      max: this.formBuilder.control('', {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      solid: this.formBuilder.control(false, {
        validators: [Validators.required],
        updateOn: 'blur'
      }),
    });
  }
  addProduct(header: any, columnIndex: number) {
    header.products.push({ name: '', min: '', max: '' });

    this.getProducts(columnIndex).push(this.createLeafProduct());
  }
  removeProduct(header: any, columnIndex: number, productIndex: number) {
    header.products.splice(productIndex, 1);

    this.getProducts(columnIndex).removeAt(productIndex);
  }

  createSoilSection(): void {
    for (let i = 0; i < this.soilRowsProductivities.length; i++)
      this.soilRows.push(this.createSoilRow(i == 0));
  }
  createSoilRow(hasB: boolean): FormGroup {
    const groupConfig: any = {
      n: this.createSoilColumn(2),
      p: this.createSoilColumn(3),
      k: this.createSoilColumn(4)
    };

    if (hasB)
      groupConfig.b = this.createSoilColumn(4);

    return this.formBuilder.group(groupConfig);
  }
  createSoilColumn(numberOfValues: number): FormGroup {
    const group: { [key: string]: FormControl } = {};

    for (let i = 1; i <= numberOfValues; i++)
      group[`value${i}`] = this.formBuilder.control('', {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      });

    return this.formBuilder.group(group);
  }

  onSubmit() {
    if (this.fertilizerTableForm.invalid)
      return this.fertilizerTableForm.markAllAsTouched();

    const formValue = this.fertilizerTableForm.value;

    //Montar dados da folha
    const headerValues = Object.values(NutrientHeaders) as string[];

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
          header: headerValues.indexOf(this.leafHeaders[colIndex].label),
          products: products
        };
      })
    };

    //Montar dados do solo
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

    const fertilizerTable: FertilizerTable = {
      id: this.fertilizerTable?.id,
      cultureId: formValue.cultureType.value,
      standard: this.user?.role == 'Admin' ? true : false,
      expectedBasesSaturation: formValue.expectedBasesSat,
      leafFertilizerRow: leafRow,
      soilFertilizerRows: soilRows
    };

    this.fertilizerTableSubmit.emit(fertilizerTable);
  }
}

export interface fertilizerTableForm {
  cultureType: string,
  standard: boolean
}