import { Injectable, TemplateRef } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ToastService {
  toasts: string[] = [];

  show(textOrTpl: string) {
    this.toasts.push(textOrTpl);
  }

  remove(toast: string) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}