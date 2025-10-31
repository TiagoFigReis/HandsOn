import { Component, EventEmitter, Input, Output, TemplateRef, ViewChild, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common'
import { Culture, CultureFacade, minMaxValidator, minMedMaxValidator, NutrientColumn, NutrientHeaders, NutrientRow, NutrientTable, User } from '@farm/core';
import { ButtonComponent } from '../../components/button/button.component';
import { FormArray, FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { SelectComponent, SelectOption } from '../../components/select/select.component';
import { TabItem, TabsComponent } from '../../components/tabs/tabs.component';
import { FieldsetComponent } from '../../components/fieldset/fieldset.component';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { NutrientTableSoilFormComponent } from './lib/soil-section/nutrient-table-soil-form.component';
import { NutrientTableLeafFormComponent } from './lib/leaf-section/nutrient-table-leaf-form.component';

@Component({
  selector: 'lib-nutrient-table-form',
  imports: [
    CommonModule,
    ButtonComponent,
    FormsModule,
    ReactiveFormsModule,
    SelectComponent,
    TabsComponent,
    FieldsetComponent,
    NutrientTableSoilFormComponent,
    NutrientTableLeafFormComponent
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

  @ViewChild('leafSection', { static: true }) leafSection!: TemplateRef<any>;
  @ViewChild('soilSection', { static: true }) soilSection!: TemplateRef<any>;

  nutrientTableForm: FormGroup;
  cultureOptions: SelectOption[] = [];
  selectDivision = true;
  divisionOptions: SelectOption[] = [
    { value: '0', label: 'Anual' },
    { value: '1', label: 'Semestral' },
    { value: '2', label: 'Trimestral' },
    { value: '3', label: 'Bimestral' }
  ];

  tabs: TabItem[] = [];
  isSmallScreen = false;
  periods: string[] = [];
  
  leafRowsCache = new Map<string, any[]>();
  previousDivisionValue = '0';

  leafHeaders = [
    {
      title: "Macronutrientes",
      items: [
        { label: 'Nitrogênio (N) - g/Kg', id: 0, key: NutrientHeaders.N },
        { label: 'Fósforo (P) - g/Kg', id: 1, key: NutrientHeaders.P },
        { label: 'Potássio (K) - g/Kg', id: 2, key: NutrientHeaders.K },
        { label: 'Cálcio (Ca) - g/Kg', id: 3, key: NutrientHeaders.Ca },
        { label: 'Magnésio (Mg) - g/Kg', id: 4, key: NutrientHeaders.Mg },
        { label: 'Enxofre (S) - g/Kg', id: 5, key: NutrientHeaders.S }
      ]
    },
    {
      title: "Micronutrientes",
      items: [
        { label: 'Zinco (Zn) - ppm', id: 6, key: NutrientHeaders.Zn },
        { label: 'Boro (B) - ppm', id: 7, key: NutrientHeaders.B },
        { label: 'Cobre (Cu) - ppm', id: 8, key: NutrientHeaders.Cu },
        { label: 'Manganês (Mn) - ppm', id: 9, key: NutrientHeaders.Mn },
        { label: 'Ferro (Fe) - ppm', id: 10, key: NutrientHeaders.Fe }
      ]
    },
    {
      title: "Relações",
      items: [
        { label: 'Nitrogênio/Fósforo (N/P)', id: 11, key: NutrientHeaders.NP },
        { label: 'Nitrogênio/Potássio (N/K)', id: 12, key: NutrientHeaders.NK },
        { label: 'Nitrogênio/Enxofre (N/S)', id: 13, key: NutrientHeaders.NS },
        { label: 'Nitrogênio/Boro (N/B)', id: 14, key: NutrientHeaders.NB },
        { label: 'Nitrogênio/Cobre (N/Cu)', id: 15, key: NutrientHeaders.NCu },
        { label: 'Fósforo/Magnésio (P/Mg)', id: 16, key: NutrientHeaders.PMg },
        { label: 'Fósforo/Zinco (P/Zn)', id: 17, key: NutrientHeaders.PZn },
        { label: 'Potássio/Cálcio (K/Ca)', id: 18, key: NutrientHeaders.KCa },
        { label: 'Potássio/Magnésio (K/Mg)', id: 19, key: NutrientHeaders.KMg },
        { label: 'Potássio/Manganês (K/Mn)', id: 20, key: NutrientHeaders.KMn },
        { label: 'Cálcio/Magnésio (Ca/Mg)', id: 21, key: NutrientHeaders.CaMg },
        { label: 'Cálcio/Manganês (Ca/Mn)', id: 22, key: NutrientHeaders.CaMn },
        { label: 'Ferro/Manganês (Fe/Mn)', id: 23, key: NutrientHeaders.FeMn }
      ]
    }
  ];

  soilHeaders = [
    {
      title: "Macronutrientes",
      items: [
        { label: 'Fósforo (P) - ppm', complex: false, id: 0, inverted: false, key: NutrientHeaders.P },
        { label: 'Potássio (K) - Cmolc/dm³', complex: false, id: 1, inverted: false, key: NutrientHeaders.K },
        { label: 'Cálcio (Ca) - Cmolc/dm³', complex: false, id: 2, inverted: false, key: NutrientHeaders.Ca },
        { label: 'Magnésio (Mg) - Cmolc/dm³', complex: false, id: 3, inverted: false, key: NutrientHeaders.Mg },
        { label: 'Enxofre (S) - ppm', complex: false, id: 4, inverted: false, key: NutrientHeaders.S }
      ]
    },
    {
      title: 'Micronutrientes',
      items: [
        { label: 'Zinco (Zn) - ppm', complex: false, id: 5, inverted: false, key: NutrientHeaders.Zn },
        { label: 'Boro (B) - ppm', complex: false, id: 6, inverted: false, key: NutrientHeaders.B },
        { label: 'Cobre (Cu) - ppm', complex: false, id: 7, inverted: false, key: NutrientHeaders.Cu },
        { label: 'Manganês (Mn) - ppm', complex: false, id: 8, inverted: false, key: NutrientHeaders.Mn },
        { label: 'Ferro (Fe) - ppm', complex: false, id: 9, inverted: false, key: NutrientHeaders.Fe }
      ]
    },
    {
      title: 'Fertilidade',
      items: [
        { label: 'Matéria Orgânica (M.O) - %', complex: false, id: 10, inverted: false, key: NutrientHeaders.OrganicMatter },
        { label: 'Soma de Bases (SB) - Cmolc/dm³', complex: true, id: 11, inverted: false, key: NutrientHeaders.SumBases },
        { label: 'CTC (T) - Cmolc/dm³', complex: true, id: 12, inverted: false, key: NutrientHeaders.CTCpH7 },
        { label: 'Sat. por Bases (v) - %', complex: true, id: 13, inverted: false, key: NutrientHeaders.BasesSaturation }
      ]
    },
    {
      title: "Acidez",
      items: [
        { label: 'pH em Água', complex: true, id: 14, inverted: false, key: NutrientHeaders.phH2O },
        { label: 'Acidez Trocável (Al³⁺) - Cmolc/dm³', complex: true, id: 15, inverted: true, key: NutrientHeaders.AlSaturation },
        { label: 'Acidez Potencial (H + Al) - Cmolc/dm³', complex: true, id: 16, inverted: true, key: NutrientHeaders.PotentialAcidity }
      ]
    }
  ];

  leafText = `Esta tabela ajuda a identificar deficiências de nutrientes nas folhas de uma plantação e recomenda os produtos ideais para corrigi-las. 
    Cada nutriente listado possui uma seleção de fertilizantes indicados para aplicação quando que os níveis estiverem abaixo do ideal. <br>
    Os valores já vêm pré-definidos por nossos especialistas, mas podem ser personalizados de acordo com as necessidades específicas de uma cultura.`;
  soilText = `Esta tabela serve como um guia para a adubação do solo com base nos teores de Nitrogênio (N), Fósforo (P), Potássio (K) e Boro (B). 
    Cada célula indica a quantidade de fertilizante a ser aplicada conforme a necessidade detectada em cada nutriente. <br>
    Todas as dosagens já são preenchidas com valores de referência estabelecidos pela nossa equipe de agrônomos, mas podem ser ajustadas para uma recomendação mais personalizada.`;

  currentText: string = this.leafText;

  constructor(
    private formBuilder: FormBuilder,
    private cultureFacade: CultureFacade,
    private breakpointObserver: BreakpointObserver
  ) {
    this.nutrientTableForm = this.formBuilder.group({
      cultureType: this.formBuilder.control('', {
        validators: [],
        updateOn: 'blur'
      }),
      tableDivision: this.formBuilder.control('', {
        validators: [],
        updateOn: 'blur'
      }),
      leafRows: this.formBuilder.array([]),
      soilRow: this.formBuilder.group({
        soilColumns: this.formBuilder.array([])
      })
    });
  }

  ngOnInit(): void {
    this.cultureFacade.getAllCulturesWithoutNutrientTable().subscribe({
      next: (cultures: Culture[]) => {
        this.cultureOptions = cultures.reduce<SelectOption[]>((acc, c) => {
          if (c.id != null) {
            acc.push({
              value: c.id.toString(), 
              label: c.name
            });
          }
          return acc;
        }, []); 
      }
    });

    if (this.selectCulture) this.cultureType.setValidators([Validators.required]);

    this.tabs = [
      { header: "Seção Folha", template: this.leafSection },
      { header: "Seção Solo", template: this.soilSection }
    ];

    this.breakpointObserver.observe([Breakpoints.Handset])
      .subscribe(result => {
        this.isSmallScreen = result.matches;
      });

    this.tableDivision.valueChanges.subscribe((value) => {
      if (value) {
        const oldData = this.leafRows.getRawValue();
        this.leafRowsCache.set(this.previousDivisionValue, oldData);
        
        this.setRowsBasedOnDivision(value.value);
        
        this.previousDivisionValue = value.value;
      }
    });
    
    this.createSoilSection();
    this.onTabChange(0);
    
    if (!this.nutrientTable) {
      this.setRowsBasedOnDivision('0');
      this.previousDivisionValue = '0';
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['nutrientTable'] && this.nutrientTable) {
      this.updateNutrientTableData();
    }
    
    if (changes['loading']) {
      if (this.loading) this.nutrientTableForm.disable();
      else this.nutrientTableForm.enable({ emitEvent: false });
    }
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
  get soilRow(): FormGroup {
    return this.nutrientTableForm.get('soilRow') as FormGroup;
  }
  get soilColumns(): FormArray {
    return this.soilRow.get('soilColumns') as FormArray;
  }
  
  createLeafRow(columnsData?: any[]): FormGroup {
    const allItems = this.leafHeaders.flatMap(group => group.items);
    const columnsArray = this.formBuilder.array(
      Array.from({ length: allItems.length }, (_, i) => {
        const data = columnsData ? columnsData[i] : undefined;
        return this.createLeafColumn(data);
      })
    );
    return this.formBuilder.group({
      leafColumns: columnsArray
    });
  }

  createLeafColumn(data?: { min: number, max: number }): FormGroup {
    return this.formBuilder.group({
      min: this.formBuilder.control(data?.min ?? 1, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
      max: this.formBuilder.control(data?.max ?? 2, {
        validators: [Validators.required, Validators.min(0)],
        updateOn: 'blur'
      }),
    }, { validators: minMaxValidator('min', 'max') });
  }

  createSoilSection(): void {
    const allItems = this.soilHeaders.flatMap(header => header.items);
    this.soilColumns.clear();
    allItems.forEach(item => {
      this.soilColumns.push(this.createSoilColumn(item.complex));
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

  setRowsBasedOnDivision(value: string): void {
    let numberOfRows = 1;

    switch (value) {
      case '1': numberOfRows = 2; break;
      case '2': numberOfRows = 4; break;
      case '3': numberOfRows = 6; break;
      default: numberOfRows = 1;
    }
    
    this.setPeriods(value);
    this.leafRows.clear();

    if (this.leafRowsCache.has(value)) {
      const cachedData = this.leafRowsCache.get(value);
      cachedData?.forEach((rowData: any) => {
        this.leafRows.push(this.createLeafRow(rowData.leafColumns));
      });
    } else {
      for (let i = 0; i < numberOfRows; i++) {
        this.leafRows.push(this.createLeafRow());
      }
    }
  }

  setPeriods(value: string): void {
    switch (value) {
      case '0': this.periods = ["Anual"]; break;
      case '1': this.periods = ["Jan-Jun", "Jul-Dez"]; break;
      case '2': this.periods = ["Jan-Mar", "Abr-Jun", "Jul-Set", "Out-Dez"]; break;
      case '3': this.periods = ["Jan/Fev", "Mar/Abr", "Mai/Jun", "Jul/Ago", "Set/Out", "Nov/Dez"]; break;
      default: this.periods = ["Anual"];
    }
  }

  updateNutrientTableData(): void {
    if (!this.nutrientTable) return;

    const selectedDivision = this.divisionOptions.find(
      opt => opt.label === this.nutrientTable?.division
    );
    const divisionValue = selectedDivision ? selectedDivision.value : '0';
    this.previousDivisionValue = divisionValue;

    this.nutrientTableForm.patchValue({
      tableDivision: { value: divisionValue, label: selectedDivision?.label },
      cultureType: { value: this.nutrientTable.cultureId }
    }, { emitEvent: false });

    this.leafRows.clear();
    this.nutrientTable.leafNutrientRows.forEach((row) => {
      const columnsData = row.nutrientColumns.map(col => ({ min: col.min, max: col.max }));
      this.leafRows.push(this.createLeafRow(columnsData));
    });

    this.leafRowsCache.set(divisionValue, this.leafRows.getRawValue());
    this.setPeriods(divisionValue);

    this.soilColumns.clear();
    this.nutrientTable.soilNutrientRow.nutrientColumns.forEach((column) => {
      const complex = column.med1 !== 0 && column.med2 !== 0;
      this.soilColumns.push(this.createSoilColumn(complex, column));
    });
  }

  onSubmit() {
    if (this.nutrientTableForm.invalid)
      return this.nutrientTableForm.markAllAsTouched();

    const formValue = this.nutrientTableForm.getRawValue();
    const headerValues = Object.values(NutrientHeaders) as string[];
    const allLeafItems = this.leafHeaders.flatMap(group => group.items);
    const allSoilItems = this.soilHeaders.flatMap(header => header.items);

    const leafRows: NutrientRow[] = formValue.leafRows.map((leafRow: any) => {
      const nutrientColumns: NutrientColumn[] = leafRow.leafColumns.map((leafColumn: any, colIndex: number) => {
        const item = allLeafItems[colIndex];
        const header = headerValues.indexOf(item.key);
        return {
          header: header,
          min: leafColumn.min,
          max: leafColumn.max
        };
      });
      return { nutrientColumns };
    });

    const soilRow: NutrientRow = {
      nutrientColumns: formValue.soilRow.soilColumns.map((soilColumn: any, colIndex: number) => {
        const item = allSoilItems[colIndex];
        const header = headerValues.indexOf(item.key);
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

    const nutrientTable: NutrientTable = {
      id: this.nutrientTable?.id,
      cultureId: formValue.cultureType.value,
      standard: this.user?.role == 'Admin' ? true : false,
      division: Number(formValue.tableDivision.value),
      leafNutrientRows: leafRows,
      soilNutrientRow: soilRow
    }

    this.nutrientTableSubmit.emit(nutrientTable);
  }

  onTabChange(index: string | number) {
    if (index === 0) {
      this.currentText = this.leafText;
      this.selectDivision = true;
      this.tableDivision.setValidators([Validators.required]);
    } else if (index === 1) {
      this.currentText = this.soilText;
      this.selectDivision = false;
      this.tableDivision.clearValidators();
    }
    this.tableDivision.updateValueAndValidity();
  }
}