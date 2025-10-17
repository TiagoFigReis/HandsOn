import { Component, EventEmitter, Input, Output, TemplateRef, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Culture, CultureFacade, FertilizerTable, NutrientHeaders, User } from '@farm/core';
import { ButtonComponent } from '../../components/button/button.component';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { SelectComponent, SelectOption } from '../../components/select/select.component';
import { InputNumberComponent } from '../../components/input-number/input-number.component';
import { TabItem, TabsComponent } from '../../components/tabs/tabs.component';
import { FertilizerTableLeafFormComponent } from './lib/leaf-section/fertilizer-table-leaf-form.component';
import { FertilizerTableSoilFormComponent } from './lib/soil-section/fertilizer-table-soil-form.component';
import { FieldsetComponent } from '../../components/fieldset/fieldset.component';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';

@Component({
  selector: 'lib-fertilizer-table-form',
  imports: [
    CommonModule,
    ButtonComponent,
    FormsModule,
    ReactiveFormsModule,
    SelectComponent,
    InputNumberComponent,
    TabsComponent,
    FieldsetComponent,
    FertilizerTableLeafFormComponent,
    FertilizerTableSoilFormComponent
  ],
  templateUrl: './fertilizer-table-form.component.html',
  styleUrl: './fertilizer-table-form.component.css',
})
export class FertilizerTableFormComponent {
  @Input() fertilizerTable: FertilizerTable | undefined;
  @Input() user: User | undefined;
  @Input() loading = false;
  @Input() selectCulture = false;
  @Input() submitLabel = 'Cadastrar';

  @Output() fertilizerTableSubmit = new EventEmitter<FertilizerTable>();

  @ViewChild('leafSection', { static: true }) leafSection!: TemplateRef<any>;
  @ViewChild('soilSection', { static: true }) soilSection!: TemplateRef<any>;
  @ViewChild(FertilizerTableLeafFormComponent) leafComponent!: FertilizerTableLeafFormComponent;
  @ViewChild(FertilizerTableSoilFormComponent) soilComponent!: FertilizerTableSoilFormComponent;

  fertilizerTableForm: FormGroup;

  cultureOptions: SelectOption[] = [];
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
    this.fertilizerTableForm = this.formBuilder.group({
      cultureType: this.formBuilder.control('', {
        validators: [],
        updateOn: 'blur'
      }),
      expectedBasesSat: this.formBuilder.control(null, {
        validators: [Validators.required, Validators.min(0), Validators.max(10000)],
        updateOn: 'blur'
      })
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

    if (this.selectCulture) this.cultureType.setValidators([Validators.required]);

    this.tabs = [
      { header: "Seção Folha", template: this.leafSection },
      { header: "Seção Solo", template: this.soilSection }
    ];

    this.breakpointObserver.observe([Breakpoints.Handset])
      .subscribe(result => {
        this.isSmallScreen = result.matches;
      });
  }

  ngOnChanges() {
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

  updateFertilizerTableData(): void {
    if (!this.fertilizerTable) return;

    this.fertilizerTableForm.patchValue({
      cultureType: { value: this.fertilizerTable.cultureId },
      expectedBasesSat: this.fertilizerTable.expectedBasesSaturation
    });
  }

  onSubmit() {
    if (this.fertilizerTableForm.invalid)
      return this.fertilizerTableForm.markAllAsTouched();

    const formValue = this.fertilizerTableForm.value;
    const headerValues = Object.values(NutrientHeaders) as string[];

    //criar a aprte da folha
    const leafRow = this.leafComponent.onSubmit(formValue, headerValues);

    //criar a aprte do solo
    const soilRows = this.soilComponent.onSubmit(formValue, headerValues);

    const fertilizerTable: FertilizerTable = {
      id: this.fertilizerTable?.id,
      cultureId: formValue.cultureType.value,
      standard: this.user?.role == 'Admin' ? true : false,
      expectedBasesSaturation: formValue.expectedBasesSat,

      soilFertilizerRows: soilRows,
      leafFertilizerRow: leafRow
    }

    this.fertilizerTableSubmit.emit(fertilizerTable);
  }

  onTabChange(index: string | number) {
    if (index === 0)
      this.currentText = this.leafText;

    else if (index === 1)
      this.currentText = this.soilText;
  }
}