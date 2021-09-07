import {Pipe, PipeTransform} from '@angular/core'
@Pipe({
    name: 'rgbToHexValues'
})

export class rgbToHexValues implements PipeTransform{
    transform(values: number[][]){
        let hexValues: string[] = [];
        for(let i= 0; values.length > i; i++){ //loops through each color
            let color = values[i];
            let hexValue = "#";
            color.forEach(part => { //loops through each
                let hex = part.toString(16).toUpperCase(); //converts decimal to upper case hex
                if(!(hex.length >1)){ //ensures 2 digit per hex value
                    hex = '0'+hex;
                }
                hexValue +=hex;
            });
             hexValues[i] = hexValue;
        }
        return hexValues;
    }
}