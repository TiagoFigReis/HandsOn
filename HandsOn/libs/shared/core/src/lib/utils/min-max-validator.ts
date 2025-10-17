import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function minMaxValidator(minControlName: string, maxControlName: string): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
        const minControl = group.get(minControlName);
        const maxControl = group.get(maxControlName);

        if (minControl && maxControl) {
            const min = minControl.value;
            const max = maxControl.value;

            if (min !== null && max !== null && max <= min) {
                maxControl.setErrors({ ...(maxControl.errors || {}), maxLessThanMin: true });

            } else {
                if (maxControl.errors) {
                    delete maxControl.errors['maxLessThanMin'];

                    if (!Object.keys(maxControl.errors).length)
                        maxControl.setErrors(null);
                }
            }
        }

        return null;
    };
}