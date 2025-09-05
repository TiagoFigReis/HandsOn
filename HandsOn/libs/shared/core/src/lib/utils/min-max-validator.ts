import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function minMaxValidator(): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
        const min = group.get('min')?.value;
        const max = group.get('max')?.value;

        if (min != null && max != null && max <= min)
            return { maxLessThanMin: true };
        
        return null;
    };
}
