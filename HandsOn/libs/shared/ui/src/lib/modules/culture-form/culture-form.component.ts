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
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ButtonComponent } from '../../components/button/button.component';
import { InputComponent } from '../../components/input/input.component';
import {
  Culture
} from '@farm/core';

@Component({
  selector: 'lib-culture-form',
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    InputComponent,
    ButtonComponent,
  ],
  templateUrl: './culture-form.component.html',
  styleUrl: './culture-form.component.css',
})
export class CultureFormComponent implements OnInit, OnChanges {
  @Input() culture: Culture | undefined;
  @Input() loading = false;
  @Input() submitLabel = 'Cadastrar';
  
  @Output() cultureSubmit = new EventEmitter<Culture>();

  cultureForm: FormGroup;

  constructor() {
    this.cultureForm = new FormGroup({
      name: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
        updateOn: 'blur',
      })
    });
  }

  ngOnInit(): void {
    if (this.culture) this.updateCultureData();
  }

  ngOnChanges(): void {
    if (this.culture) this.updateCultureData();

    if (this.loading) this.cultureForm.disable();
    else this.cultureForm.enable();
  }

  get name(): FormControl {
    return this.cultureForm.get('name') as FormControl;
  }

  updateCultureData(): void {
    if (!this.culture) return;

    this.cultureForm.patchValue({
      name: this.culture.name
    });
  }

  onSubmit() {
    if (this.cultureForm.invalid) {
      return this.cultureForm.markAllAsTouched();
    }

    const formValue = this.cultureForm.value;

    const culture: Culture = {
      id: this.culture?.id,
      name: formValue.name
    }

    this.cultureSubmit.emit(culture);
  }
}

export interface cultureForm {
  name: string
}

