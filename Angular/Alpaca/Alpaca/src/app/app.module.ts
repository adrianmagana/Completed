import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CanvasComponent } from './components/canvas/canvas.component';
import { RemoveExtensionPipe } from './pipes/remove-extension.pipe';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from './components/main/app.component';

@NgModule({
  declarations: [
    AppComponent,
    CanvasComponent,
    RemoveExtensionPipe
  ],
  imports: [
    BrowserModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
