import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'removeExtension'
})

export class RemoveExtensionPipe implements PipeTransform{
    transform(path: string): string{
        let fileName: string = path.split('/').pop(); 
        return fileName.split('.')[0];
    }
}