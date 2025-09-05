import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function minMedMaxValidator(inverted: boolean): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
        const min = group.get('min')?.value;
        const med1 = group.get('med1')?.value;
        const med2 = group.get('med2')?.value;
        const max = group.get('max')?.value;

        if ([min, med1, med2, max].some(v => v == null || v === ''))
            return null;

        if (inverted) {
            if (!(min > med1 && med1 > med2 && med2 > max)) 
                return { invalidSequence: true };
        } else {
            if (!(min < med1 && med1 < med2 && med2 < max))
                return { invalidSequence: true };
        }

        return null;
    };
}