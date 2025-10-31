import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import {
  CulturesListComponentFacade,
  CultureWithActions,
} from './cultures-list.component.facade';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Culture } from '@farm/core';
import { InputCultureComponent, ButtonComponent } from '@farm/ui'; 

@Component({
  selector: 'lib-cultures-list',
  imports: [
    CommonModule,
    RouterLink,
    FormsModule,
    ReactiveFormsModule,
    InputCultureComponent, 
    ButtonComponent,  
  ],
  templateUrl: './cultures-list.component.html',
  styleUrl: './cultures-list.component.css',
})
export class CulturesListComponent implements OnInit {
  data: CultureWithActions[] = [];
  loading = false;
  submitting = false;
  submitLabel = 'Cadastrar Cultura';
  cultureForm: FormGroup;

  constructor(private facade: CulturesListComponentFacade) {
    this.cultureForm = new FormGroup({
      name: new FormControl('', {
        validators: [
          Validators.required,
          Validators.minLength(2),
          Validators.maxLength(50),
        ],
        updateOn: 'blur',
      }),
    });
  }

  ngOnInit(): void {
    this.facade.loading$.subscribe((loading) => {
      this.loading = loading;
    });

    this.facade.submitting$.subscribe((submitting) => {
      this.submitting = submitting;
    });

    this.facade.cultures$.subscribe((cultures) => {
      this.data = cultures.map(c => {
        const lower = c.name.toLowerCase();
        c.name = lower.charAt(0).toUpperCase() + lower.slice(1);
        return c;
      });
    });

    this.facade.load();
  }

  get name(): FormControl {
    return this.cultureForm.get('name') as FormControl;
  }

  refresh() {
    this.facade.load();
  }

  onSubmit() {
    if (this.cultureForm.invalid) {
      return this.cultureForm.markAllAsTouched();
    }

    const formValue = this.cultureForm.value;

    const culture: Culture = {
      name: formValue.name,
    };

    this.facade.submit(culture);
    this.cultureForm.reset();
  }
}