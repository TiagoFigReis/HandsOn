import { Component, EventEmitter, Input, Output, TemplateRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Culture, CultureFacade, NutrientHeaders, NutrientTable, User } from '@farm/core';
import { ButtonComponent } from '../../components/button/button.component';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
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
export class NutrientTableFormComponent {
  @Input() nutrientTable: NutrientTable | undefined;
  @Input() user: User | undefined;
  @Input() loading = false;
  @Input() selectCulture = false;
  @Input() submitLabel = 'Cadastrar';

  @Output() nutrientTableSubmit = new EventEmitter<NutrientTable>();

  @ViewChild('leafSection', { static: true }) leafSection!: TemplateRef<any>;
  @ViewChild('soilSection', { static: true }) soilSection!: TemplateRef<any>;
  @ViewChild(NutrientTableSoilFormComponent) soilComponent!: NutrientTableSoilFormComponent;
  @ViewChild(NutrientTableLeafFormComponent) leafComponent!: NutrientTableLeafFormComponent;

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

  leafText: string = `Esta tabela ajuda a identificar deficiências de nutrientes nas folhas de uma plantação e recomenda os produtos ideais para corrigi-las. 
    Cada nutriente listado possui uma seleção de fertilizantes indicados para aplicação quando que os níveis estiverem abaixo do ideal. <br>
    Os valores já vêm pré-definidos por nossos especialistas, mas podem ser personalizados de acordo com as necessidades específicas de uma cultura.`;
  soilText: string = `Esta tabela serve como um guia para a adubação do solo com base nos teores de Nitrogênio (N), Fósforo (P), Potássio (K) e Boro (B). 
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
      })
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

    if (this.selectCulture) this.cultureType.setValidators([Validators.required]);
    if (this.selectDivision) this.tableDivision.setValidators([Validators.required]);

    this.tabs = [
      { header: "Seção Folha", template: this.leafSection },
      { header: "Seção Solo", template: this.soilSection }
    ];

    this.breakpointObserver.observe([Breakpoints.Handset])
      .subscribe(result => {
        this.isSmallScreen = result.matches;
      });

    this.tableDivision.valueChanges.subscribe((value) => {
      this.leafComponent.setRowsBasedOnDivision(value.value);
    });
  }

  ngOnChanges() {
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

  updateNutrientTableData(): void {
    if (!this.nutrientTable) return;

    const selectedDivision = this.divisionOptions.find(
      opt => opt.label === this.nutrientTable?.division
    );

    this.nutrientTableForm.patchValue({
      tableDivision: { value: selectedDivision!.value, label: selectedDivision!.label },
      cultureType: { value: this.nutrientTable.cultureId }
    }, { emitEvent: false });

    this.leafComponent.setPeriods(this.tableDivision.value.value);
  }

  onSubmit() {
    if (this.nutrientTableForm.invalid)
      return this.nutrientTableForm.markAllAsTouched();

    const formValue = this.nutrientTableForm.value;
    const headerValues = Object.values(NutrientHeaders) as string[];

    //criar a aprte da folha
    const leafRows = this.leafComponent.onSubmit(formValue);

    //criar a aprte do solo
    const soilRow = this.soilComponent.onSubmit(formValue, headerValues);

    const nutrientTable: NutrientTable = {
      id: this.nutrientTable?.id,
      cultureId: formValue.cultureType.value,
      standard: this.user?.role == 'Admin' ? true : false,
      division: formValue.division,
      leafNutrientRows: leafRows,
      soilNutrientRow: soilRow
    }

    this.nutrientTableSubmit.emit(nutrientTable);
  }

  onTabChange(index: string | number) {
    if (index === 0) {
      this.currentText = this.leafText;
      this.selectDivision = true;
    }

    else if (index === 1) {
      this.currentText = this.soilText;
      this.selectDivision = false;
    }
  }
}