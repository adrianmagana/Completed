import { Component, OnInit } from '@angular/core';
import { ColorMindService } from "src/app/services/color-mind-service";
import { ToastService } from 'src/app/services/toast-service';
@Component({
    selector: 'color-cards',
    templateUrl: './color-cards.component.html',
    styleUrls: ['./color-cards.component.css']
  })
  
  export class ColorCardsComponent{
   rgbValues: number[][];
   errorDisplay: string = 'none';
  
    constructor(private ColorMindService: ColorMindService, private ToastService: ToastService) {
       this.rgbValues = [];
       this.generatePalette();
    }


    showToast(hex: string){
        this.ToastService.show(hex);
    }

    generatePalette(){
        this.errorDisplay = 'none';
        this.ColorMindService.getPalette().subscribe(data => {
            this.rgbValues = data.result;
        },
        error =>{
           console.log(error);
           this.displayError();
        } );
    }

    displayError(){
        this.errorDisplay = 'block';
    }
    clearError(){
        this.errorDisplay = 'none';
    }

    copyToClipboard(value: string){
        const selBox = document.createElement('textarea'); //creates invisible textbox 
        selBox.style.position = 'fixed';
        selBox.style.right = '0';
        selBox.style.bottom = '0';
        selBox.style.width='0';
        selBox.style.height='0';
        selBox.style.opacity = '0';
        selBox.value = value; //puts selected hex value in textbox
        document.body.appendChild(selBox);
        selBox.focus();
        selBox.select();
        document.execCommand('copy'); //copies selected value to users clipboard
        document.body.removeChild(selBox); //deletes temporary textbox
        this.showToast(value);
    }
  }
  