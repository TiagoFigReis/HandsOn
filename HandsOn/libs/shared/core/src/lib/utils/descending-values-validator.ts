import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function descendingValuesValidator(controlNames: string[]): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
        if (!group) return null;

        let hasError = false;

        controlNames.forEach(name => {
            const control = group.get(name);
            if (control?.errors?.['notDescending']) {
                const { notDescending, ...others } = control.errors;
                control.setErrors(Object.keys(others).length ? others : null);
            }
        });

        for (let i = 0; i < controlNames.length - 1; i++) {
            const currentControl = group.get(controlNames[i]);
            const nextControl = group.get(controlNames[i + 1]);

            if (!currentControl || !nextControl) continue;

            const current = currentControl.value;
            const next = nextControl.value;

            if (
                current !== null && current !== undefined &&
                next !== null && next !== undefined &&
                current < next
            ) {
                for (let j = 0; j <= i + 1; j++) {
                    const ctrl = group.get(controlNames[j]);
                    if (ctrl) {
                        ctrl.setErrors({
                            ...(ctrl.errors || {}),
                            notDescending: true
                        });
                    }
                }

                hasError = true;
            }
        }

        return hasError ? { notDescending: true } : null;
    };
}