import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Image } from '../../models/image';
import { GetImagesService } from '../../services/get-images.service';
@Component({
  selector: 'app-canvas',
  templateUrl: './canvas.component.html',
  styleUrls: ['./canvas.component.css']
})

export class CanvasComponent {
  @ViewChild('canvas') canvas;
  color: string;
  ctx: CanvasRenderingContext2D;
  categories: string[];
  selectedCategory: string = 'hair';
  currentStyles: string[];
  displayedStyles: Image[] = [ //order of items is draw order
    {
      category: 'necks',
      filename: 'default.png'
    },
    {
      category: 'noses',
      filename: 'nose.png'
    },
    {
      category: 'ears',
      filename: 'default.png'
    },
    {
      category: 'hair',
      filename: 'default.png'
    },
    {
      category: 'legs',
      filename: 'default.png'
    },
    {
      category: 'mouths',
      filename: 'default.png'
    },
    {
      category: 'eyes',
      filename: 'default.png'
    },
    {
      category: 'accessories',
      filename: 'none'
    }
  ];

  constructor(private imagesService: GetImagesService) {
    this.categories = imagesService.getCategories();
    this.currentStyles = imagesService.getImages(this.selectedCategory);
  } 


  ngAfterViewInit() {
    this.ctx = this.canvas.nativeElement.getContext('2d');
    this.drawAlpaca();
  }

  changeStyle(style: string) {
    for (let i = 0; this.displayedStyles.length > i; i++) {  //interates parts list
      if (this.displayedStyles[i].category == this.selectedCategory && this.displayedStyles[i].filename != style){ //finds matching category
        this.displayedStyles[i].filename = style;//replaces style
        this.drawAlpaca(); //redraws alpaca
        i = this.displayedStyles.length; 
      }
    }
    
  }

  changeCategory(category: string){
    if (category != this.selectedCategory) {
      this.currentStyles = this.imagesService.getImages(category);
      this.selectedCategory = category;
    }
  }

  changeColor(val: string){
    this.color = val;
    this.drawAlpaca();
  }

  async drawAlpaca() {
    let start = performance.now();
    console.log(start);
    this.ctx.fillStyle = this.color;
    this.ctx.fillRect(0, 0, this.ctx.canvas.width, this.ctx.canvas.height);
    let images: Promise<HTMLImageElement>[] =[];

    for (let style of this.displayedStyles) { //starts to load each image to be drawn
      if (style.filename != '' && style.filename != 'none') {
        images.push(this.imagesService.loadImage(style.category + '/' + style.filename));
      }
    }

    for (let image of images) {  //draws images in proper order and waits for image to be loaded as needed
      await this.drawImage(image);
    }
    console.log('time taken: ' + (performance.now()-start));
  }

  async drawImage(image: Promise<HTMLImageElement>) {
    const img = await image;
    this.ctx.drawImage(img, 0, 0, img.width, img.height);
  }

  randomize(){
    this.displayedStyles.forEach(style => {
      if (style.category != 'noses') { //noses category currently not utilized
        style.filename = this.imagesService.getRandomStyle(style.category);
      }
    });
    this.drawAlpaca();
  }

  download() {
    // get image data and transform mime type to application/octet-stream
    let canvasDataUrl = this.ctx.canvas.toDataURL()
      .replace(/^data:image\/[^;]*/, 'data:application/octet-stream');
    let link = document.createElement('a'); // create an anchor tag

    // set parameters for downloading
    link.setAttribute('href', canvasDataUrl);
    link.setAttribute('target', '_blank');
    link.setAttribute('download', 'alpaca.png');

    // compat mode for dispatching click on your anchor
    if (document.createEvent) {
      let evtObj = document.createEvent('MouseEvents');
      evtObj.initEvent('click', true, true);
      link.dispatchEvent(evtObj);
    } else if (link.click) {
      link.click();
    }
  }
}