import { Inject, Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors } from '@angular/forms';
import { TuiValidationError } from '@taiga-ui/cdk';
import { TuiAlertService } from '@taiga-ui/core';

@Injectable()
export class UtilsServices {
  constructor(
    @Inject(TuiAlertService) private readonly alerts: TuiAlertService
  ) {}

  // TODO: handle message
  handleMessage(
    message: string,
    type: 'error' | 'success' | 'info',
    time?: number
  ) {
    this.alerts
      .open(message, {
        label: this.capitalize(type),
        status: type,
        autoClose: time || 3000,
      })
      .subscribe();
  }

  // TODO: capitalize first letter
  capitalize(s: string) {
    return s[0].toUpperCase() + s.slice(1);
  }

  // TODO: Validate
  maxLengthValidator(type: string, limit: number): (
    field: AbstractControl
  ) => ValidationErrors | null {
    return (field: AbstractControl): ValidationErrors | null =>
      field?.value?.length > limit
        ? {
            length: new TuiValidationError(
              `${type} cannot be longer than ${limit} characters.`
            ),
          }
        : null;
  }
}
