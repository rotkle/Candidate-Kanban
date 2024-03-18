import { Inject, Injectable } from '@angular/core';
import { TuiAlertService } from '@taiga-ui/core';

@Injectable()
export class UtilsServices {
  constructor(
    @Inject(TuiAlertService) private readonly alerts: TuiAlertService
  ) {}

  // TODO: handle message
  handleMessage(message: string, type: 'error' | 'success' | 'info', time?: number) {
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
}
