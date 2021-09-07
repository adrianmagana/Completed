import { Component } from "@angular/core";
import { ToastService } from "src/app/services/toast-service";

@Component({
    selector: 'toasts',
    templateUrl: './toasts.component.html', 
    styleUrls: ['./toasts.component.css'],
    host: {'[class.ngb-toasts]': 'true'}
  })
  export class ToastsComponent {
    constructor(public toastService: ToastService) {}
  
  }