import { Component, Injector, Input, OnInit, forwardRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ControlValueAccessor,
  FormsModule,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
  NgControl
} from '@angular/forms';
import { DatePicker, DatePickerTypeView } from 'primeng/datepicker';

@Component({
  selector: 'lib-date-picker',
  standalone: true, 
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DatePicker
  ],
  templateUrl: './datePicker.component.html',
  styleUrl: './datePicker.component.css',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => DatePickerComponent),
      multi: true,
    },
  ],
})
export class DatePickerComponent implements ControlValueAccessor, OnInit {
  @Input() fluid = false;
  @Input() placeholder = '';
  @Input() id = '';
  @Input() label = '';
  @Input() dateFormat = 'dd/mm/yy'; 
  @Input() view: DatePickerTypeView = 'date';

  value: Date | null = null;
  disabled = false;
  ngControl: NgControl | null = null;

  onChange: (value: string | null) => void = () => {return};
  onTouched: () => void = () => {return};

  constructor(
      private injector: Injector
    ) {}

  writeValue(value: string | null): void {
    this.value = value ? new Date(value) : null;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  ngOnInit(): void {
    this.ngControl = this.injector.get(NgControl, null);
    if (this.ngControl) {
      this.ngControl.valueAccessor = this;
    }
  }

  get errorMessage(): string | null {
    if (!this.ngControl?.invalid || !(this.ngControl.dirty || this.ngControl.touched)) {
      return null;
    }

    const errors = this.ngControl.errors;
    if (!errors) {
      return null;
    }

    const errorKey = Object.keys(errors)[0];

    const message = errorMessages[errorKey as keyof typeof errorMessages].replace(
        '{0}', this.label);

    return message
  }

  onDateChange(dateValue: Date | null): void {
    this.value = dateValue;

    if (dateValue) {
      const formattedDate = dateValue.toISOString().slice(0, 10);
      this.onChange(formattedDate); 
    } else {
      this.onChange(null); 
    }
  }
}

const errorMessages = {
    required: '{0} é obrigatório',
    date: 'A data não deve ser futura'
}