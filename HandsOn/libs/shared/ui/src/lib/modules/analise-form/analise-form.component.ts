import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  Output,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import { UploadFileComponent } from '../../components/upload-file/upload-file.component';
import {
  SelectOption,
  SelectComponent,
} from '../../components/select/select.component';
import {
  Analise,
  validateDate,
} from '@farm/core';
import {AnaliseFormComponentFacade} from './analise-form.component.facade'

@Component({
  selector: 'lib-analise-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    UploadFileComponent,
    ButtonComponent,
    SelectComponent
  ],
  templateUrl: './analise-form.component.html',
  styleUrl: './analise-form.component.css',
})
export class AnaliseFormComponent implements OnChanges {
  @Input() analise: Analise | undefined;
  @Input() loading = false;
  @Input() submitLabel = 'Adicionar';

  @Output() analiseSubmit = new EventEmitter<Analise>();

  analiseForm: FormGroup;
  tipoOptions: SelectOption[] = [
    { value: '0', label: 'Solo' },
    { value: '1', label: 'Foliar' },
  ];

  arquivo : File | undefined = undefined

  maxValue = Number.MAX_VALUE;
  
  constructor(
    private facade: AnaliseFormComponentFacade,
  ) {
    this.analiseForm = new FormGroup({
      lab: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(100)
        ],
        updateOn: 'blur'}),
      tipo: new FormControl('', 
        { validators: 
            [Validators.required,], 
          updateOn: 'blur'
        }),
      proprietario: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(100)
        ],
        updateOn: 'blur'
      }),
      propriedade: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(100)
        ],
        updateOn: 'blur'
      }),
      date: new FormControl('', {
        validators: [
          Validators.required,
          validateDate
        ],
        updateOn: 'blur'
      }),
      file: new FormControl('', {
        validators: [
          Validators.required,
        ],
        updateOn: 'blur'
      })
    })
  }

  ngOnChanges(): void {
    if (this.analise) this.updateAnaliseData();

    if (this.loading) this.analiseForm.disable();
    else this.analiseForm.enable();
  }

  get tipo(): FormControl {
    return this.analiseForm.get('tipo') as FormControl;
  }

  get lab(): FormControl {
    return this.analiseForm.get('lab') as FormControl;
  }

  get proprietario(): FormControl {
    return this.analiseForm.get('proprietario') as FormControl;
  }

  get propriedade(): FormControl {
    return this.analiseForm.get('propriedade') as FormControl;
  }

  get date(): FormControl {
    return this.analiseForm.get('date') as FormControl;
  }

  get file(): FormControl{
    return this.analiseForm.get('file') as FormControl
  }

  updateAnaliseData(): void {
  if (!this.analise) return;

  let tipo = null;

  if (this.analise.tipo) {
    const tipoName = this.analise.tipo;
    tipo = this.tipoOptions.find((option) => option.label === tipoName);
  }

  this.facade.getfile(this.analise.id);

  this.facade.file$.subscribe((blob) => {
    if (!blob || !this.analise) return;

    const mime = blob.type || 'application/octet-stream';
    const ext = mime.split('/')[1] || 'bin';

    this.arquivo = new File([blob], `Analise.${ext}`, { type: mime });
    
    this.analiseForm.patchValue({
      lab: this.analise.lab,
      proprietario: this.analise.proprietario,
      propriedade: this.analise.propriedade,
      tipo: tipo,
      date: this.analise.dataAnalise,
      file: this.arquivo
    });
  });
}

  onSubmit() {
      if (this.analiseForm.invalid) {
        return this.analiseForm.markAllAsTouched();
      }

      const analise: Analise = {
        id: this.analise?.id,
        lab: this.lab.value,
        proprietario: this.proprietario.value,
        propriedade: this.propriedade.value,
        dataAnalise: this.date.value,
        file: this.file.value,
      };

      const tipo = this.tipo.value;

      if (tipo && tipo.label) analise.tipo = (tipo.label);
  
      this.analiseSubmit.emit(analise);
    }
}

export interface AnaliseForm {
  lab: string;
  proprietario: string;
  proriedade: string;
  data: Date;
}
