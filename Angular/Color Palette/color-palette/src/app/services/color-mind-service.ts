import { Injectable } from "@angular/core";
import { HttpClient, HttpParams, HttpRequest } from '@angular/common/http'; 
import { ColorResponse } from "../models/ColorResponse";

@Injectable({
    providedIn : 'root'
})

export class ColorMindService {
    _apiURL: string = "http://colormind.io/api/";
    constructor(private client: HttpClient){   
    }

    getPalette(){
        const body = JSON.stringify({
            model: "default"
        });
        return this.client.post<ColorResponse>(this._apiURL, body);
    }
}