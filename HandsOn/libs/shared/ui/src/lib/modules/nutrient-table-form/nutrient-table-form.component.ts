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
  NutrientTable,
  NutrientRow,
  NutrientColumn,
  CultureFacade,
  Culture,
  User,
  NutrientHeaders,
  minMaxValidator,
  minMedMaxValidator
} from '@farm/core';
import { SelectComponent, SelectOption } from '../../components/select/select.component';
import { InputNutrientTableComponent } from '../../components/input-nutrient-table/input-nutrient-table.component';

@Component({
  selector: 'lib-nutrient-table-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonComponent,
    SelectComponent,
    InputNutrientTableComponent
  ],
  templateUrl: './nutrient-table-form.component.html',
  styleUrl: './nutrient-table-form.component.css',
})
export class NutrientTableFormComponent implements OnInit, OnChanges {
  @Input() nutrientTable: NutrientTable | undefined;
  @Input() user: User | undefined;
  @Input() loading = false;
  @Input() selectCulture = false;
  @Input() submitLabel = 'Cadastrar';

  @Output() nutrientTableSubmit = new EventEmitter<NutrientTable>();

  nutrientTableForm: FormGroup;

  periods: string[] = []
  divisionOptions: SelectOption[] = [
    { value: '0', label: 'Anual' },
    { value: '1', label: 'Semestral' },
    { value: '2', label: 'Trimestral' },
    { value: '3', label: 'Bimestral' }
  ];
  activeTable = 'leaf';
  cultureOptions: SelectOption[] = [];

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
  soilHeaders = [
    {
      title: "Macronutrientes",
      items: [
        { label: 'P<br>(ppm)', complex: true, id: 0, inverted: false },
        { label: 'K<br>(Cmolc/dm3)', complex: true, id: 1, inverted: false },
        { label: 'Ca<br>(Cmolc/dm3)', complex: false, id: 2, inverted: false },
        { label: 'Mg<br>(Cmolc/dm3)', complex: false, id: 3, inverted: false },
        { label: 'S<br>(ppm)', complex: false, id: 4, inverted: false }
      ]
    },
    {
      title: 'Micronutrientes',
      items: [
        { label: 'Zn<br>(ppm)', complex: false, id: 5, inverted: false },
        { label: 'B<br>(ppm)', complex: false, id: 6, inverted: false },
        { label: 'Cu<br>(ppm)', complex: false, id: 7, inverted: false },
        { label: 'Mn<br>(ppm)', complex: false, id: 8, inverted: false },
        { label: 'Fe<br>(ppm)', complex: false, id: 9, inverted: false }
      ]
    },
    {
      title: 'Fertilidade',
      items: [
        { label: 'Matéria Orgânica<br>(%)', complex: true, id: 10, inverted: false },
        { label: 'Soma de Bases<br>(Cmolc/dm3)', complex: true, id: 11, inverted: false },
        { label: 'CTC<br>(Cmolc/dm3)', complex: true, id: 12, inverted: false },
        { label: 'Sat. por Bases<br>(%)', complex: true, id: 13, inverted: false }
      ]
    },
    {
      title: "Acidez",
      items: [
        { label: 'pH em Água', complex: false, id: 14, inverted: false },
        { label: 'Saturação por Al', complex: true, id: 15, inverted: true },
        { label: 'Acidez Potencial<br>(Cmolc/dm3)', complex: true, id: 16, inverted: true }
      ]
    }
  ];

  constructor(
    private formBuilder: FormBuilder,
    private cultureFacade: CultureFacade
  ) {
    this.nutrientTableForm = this.formBuilder.group({
      cultureType: this.formBuilder.control('', {
        validators: [],
        updateOn: 'blur'
      }),
      tableDivision: this.formBuilder.control('', {
        validators: [Validators.required],
        updateOn: 'blur'
      }),
      leafRows: this.formBuilder.array([]),
      soilRow: this.formBuilder.group([])
    });
  }

  ngOnInit(): void {
    this.cultureFacade.getAllCulturesWithoutNutrientTable().subscribe({
      next: (cultures: Culture[]) => {
        this.cultureOptions = cultures.map(c => ({
          value: c.id?.toString()!,
          label: c.name
        }));
      }
    });

    if (this.nutrientTable) this.updateNutrientTableData();

    this.tableDivision.valueChanges.subscribe((value) => {
      this.setRowsBasedOnDivision(value.value);
    });

    this.soilRow.addControl('soilColumns', this.createSoilRow().get('soilColumns'));

    if (this.selectCulture) this.cultureType.setValidators([Validators.required]);
  }

  ngOnChanges(): void {
    if (this.nutrientTable) this.updateNutrientTableData();

    if (this.loading) this.nutrientTableForm.disable();
    else this.nutrientTableForm.enable({ emitEvent: false });
  }

  get cultureType(): FormControl {
    return this.nutrientTableForm.get('cultureType') as FormControl;
  }
  get tableDivision(): FormControl {
    return this.nutrientTableForm.get('tableDivision') as FormControl;
  }

  get leafRows(): FormArray {
    return this.nutrientTableForm.get('leafRows') as FormArray;
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

  get soilRow(): FormGroup {
    return this.nutrientTableForm.get('soilRow') as FormGroup;
  }
  getSoilColumns(): FormArray {
    return this.soilRow.get('soilColumns') as FormArray;
  }
  getMinSoil(index: number): FormControl {
    return this.getSoilColumns().at(index).get('min') as FormControl;
  }
  getMaxSoil(index: number): FormControl {
    return this.getSoilColumns().at(index).get('max') as FormControl;
  }
  getMed1Soil(index: number) {
    return this.getSoilColumns().at(index).get('med1') as FormControl;
  }
  getMed2Soil(index: number) {
    return this.getSoilColumns().at(index).get('med2') as FormControl;
  }

  updateNutrientTableData(): void {
    if (!this.nutrientTable) return;

    const selectedDivision = this.divisionOptions.find(
      opt => opt.label === this.nutrientTable?.division
    );

    this.nutrientTableForm.patchValue({
      tableDivision: { value: selectedDivision!.value, label: selectedDivision!.label },
      cultureType: { value: this.nutrientTable.cultureId }
    }, { emitEvent: false });

    this.setPeriods(this.tableDivision.value.value);

    //Carregar as linhas de folha
    const leafRowsFormArray = new FormArray<FormGroup>([]);

    this.nutrientTable.leafNutrientRows.forEach((leafNutrientRow) => {
      const leafColumnsFormArray = new FormArray(
        leafNutrientRow.nutrientColumns.map(leafColumn =>
          this.createLeafColumn(leafColumn)
        )
      );

      const rowFormGroup = this.formBuilder.group({
        leafColumns: leafColumnsFormArray,
      });

      leafRowsFormArray.push(rowFormGroup);
    });

    this.nutrientTableForm.setControl('leafRows', leafRowsFormArray);

    //Carregar a linha de solo
    const soilColumnsFormArray = new FormArray(
      this.nutrientTable.soilNutrientRow.nutrientColumns.map(soilColumn =>
        this.createSoilColumn(soilColumn.med1 !== 0, soilColumn.inverted, soilColumn)
      )
    );

    const soilRowFormGroup = this.formBuilder.group({
      soilColumns: soilColumnsFormArray
    });

    this.nutrientTableForm.setControl('soilRow', soilRowFormGroup);
  }

  setLeafSection(): void {
    this.activeTable = 'leaf';
  }
  setSoilSection(): void {
    this.activeTable = 'soil';
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

  createLeafRow(): FormGroup {
    return this.formBuilder.group({
      leafColumns: this.formBuilder.array(
        Array.from({ length: this.leafHeaders.length }, () => this.createLeafColumn())
      )
    });
  }
  createLeafColumn(data?: { min: number, max: number }): FormGroup {
    return this.formBuilder.group({
      min: this.formBuilder.control(data?.min ?? '', {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      max: this.formBuilder.control(data?.max ?? '', {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
    }, { validators: minMaxValidator() });
  }

  createSoilRow(): FormGroup {
    const allItems = this.soilHeaders.flatMap(header => header.items);

    return this.formBuilder.group({
      soilColumns: this.formBuilder.array(
        allItems.map(item => this.createSoilColumn(item.complex, item.inverted))
      )
    });
  }
  createSoilColumn(complex: boolean, inverted: boolean, data?: { min: number, med1: number, med2: number, max: number }): FormGroup {
    return this.formBuilder.group({
      min: this.formBuilder.control(data?.min ?? '', {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      med1: this.formBuilder.control(complex ? data?.med1 ?? '' : 0, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      med2: this.formBuilder.control(complex ? data?.med2 ?? '' : 0, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      max: this.formBuilder.control(data?.max ?? '', {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
    }, { validators: complex ? minMedMaxValidator(inverted) : minMaxValidator() });
  }

  onSubmit() {
    if (this.nutrientTableForm.invalid)
      return this.nutrientTableForm.markAllAsTouched();

    const formValue = this.nutrientTableForm.value;

    //Montar dados da folha
    const leafData: NutrientRow[] = formValue.leafRows.map((leafRow: any, rowIndex: number) => {
      const nutrientColumns: NutrientColumn[] = leafRow.leafColumns.map((leafColumn: any, colIndex: number) => ({
        header: colIndex,
        min: leafColumn.min,
        max: leafColumn.max,
      }));

      return {
        nutrientColumns
      };
    });

    //Montar dados do solo
    const allItems = this.soilHeaders.flatMap(header => header.items);
    const headerValues = Object.values(NutrientHeaders) as string[];

    const soilData: NutrientRow = {
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

    //Montar Tabela
    const nutrientTable: NutrientTable = {
      id: this.nutrientTable?.id,
      cultureId: formValue.cultureType.value,
      standard: this.user?.role == 'Admin' ? true : false,
      division: +formValue.tableDivision.value,
      leafNutrientRows: leafData,
      soilNutrientRow: soilData,
      userId: '',
    };

    console.log(nutrientTable);
    
    this.nutrientTableSubmit.emit(nutrientTable);
  }
}

export interface nutrientTableForm {
  cultureType: string,
  division: string,
  standard: boolean,
  leafNutrientRows: string,
  soilNutrientRows: string
}