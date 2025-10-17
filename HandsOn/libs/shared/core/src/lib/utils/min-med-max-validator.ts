import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function minMedMaxValidator(complex: boolean): ValidatorFn {
    return (group: AbstractControl): ValidationErrors | null => {
        if (!group) return null;

        const minCtrl = group.get('min');
        const med1Ctrl = group.get('med1');
        const med2Ctrl = group.get('med2');
        const maxCtrl = group.get('max');

        const min = minCtrl?.value;
        const med1 = med1Ctrl?.value;
        const med2 = med2Ctrl?.value;
        const max = maxCtrl?.value;

        // 🔹 limpar erros anteriores
        [minCtrl, med1Ctrl, med2Ctrl, maxCtrl].forEach(ctrl => {
            if (ctrl?.errors?.['notOrdered']) {
                const { notOrdered, ...others } = ctrl.errors;
                ctrl.setErrors(Object.keys(others).length ? others : null);
            }
        });

        let hasError = false;

        if (complex) {
            // regra: min < med1 < med2 < max
            if (
                (min !== null && med1 !== null && min >= med1) ||
                (med1 !== null && med2 !== null && med1 >= med2) ||
                (med2 !== null && max !== null && med2 >= max)
            ) {
                hasError = true;
            }
        } else {
            // regra: max > min
            if (min !== null && max !== null && max <= min) {
                hasError = true;
            }
        }

        if (hasError) {
            // aplica erro em todos os controles
            [minCtrl, med1Ctrl, med2Ctrl, maxCtrl].forEach(ctrl => {
                if (ctrl) {
                    ctrl.setErrors({
                        ...(ctrl.errors || {}),
                        notOrdered: true
                    });
                }
            });
            return { notOrdered: true };
        }

        return null;
    };
}
