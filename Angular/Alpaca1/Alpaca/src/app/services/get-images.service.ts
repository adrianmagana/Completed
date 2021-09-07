import { Injectable } from "@angular/core"
import { parts, pathRoot } from "../data"

@Injectable({
  providedIn: 'root'
})

export class GetImagesService {
  private categories: string[] = [];
  constructor() {
    parts.forEach(part => {
      this.categories.push(part.category);
    });
  }

  getCategories(): string[] {
    return this.categories;
  }

  //used when loading category styles 
  getImages(category: string): string[] {
    let filenames: string[] = [];
    for (let i = 0; parts.length > i; i++) {  //interates parts list
      if (parts[i].category == category) { //finds matching category
        filenames = parts[i].paths;
        i = parts.length; //escapes for loop
      }
    }
    return filenames;
  }

  getRandomStyle(category: string): string{
    let style : string ='';
    for (let i = 0; parts.length > i; i++) {  //interates parts list
      if (parts[i].category == category) { //finds matching category
        style = parts[i].paths[Math.floor(Math.random() * (parts[i].paths.length))]; //grabS random style within category
        i = parts.length; //escapes for loop
      }
    }
    return style;
  }

  //returns promise that gives image once loaded
  loadImage(file: string): Promise<HTMLImageElement> {
    const image = new Image();
    image.src = pathRoot + file;
    return new Promise(resolve => {
      image.onload = (ev) => {
        resolve(image);
      }
    });
  }
}