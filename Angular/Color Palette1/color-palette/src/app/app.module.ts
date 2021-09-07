import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ColorCardsComponent } from './components/color-cards/color-cards.component';
import { NgbModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { rgbToHexValues } from './pipes/rgb-to-hex-values.pipe';
import { ToastsComponent } from './components/toasts/toasts.component';
import { AppComponent } from './components/main/app.component';

@NgModule({
  declarations: [
    AppComponent,
    ColorCardsComponent,
    ToastsComponent,
    rgbToHexValues
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    NgbToastModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
