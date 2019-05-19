package com.example.project343;

import android.graphics.Bitmap;

public class Background {
	Bitmap bg1;
	Bitmap bg2;
	Bitmap bg3;
	int currentBgNum;
	Bitmap currentBg;
	Background(Bitmap b1, Bitmap b2, Bitmap b3){
		bg1 = currentBg =b1;
		bg2 = b2;
		bg3 = b3;
		currentBgNum = 1;
	}
	
	public Bitmap getBit(){
		return currentBg;
		}
	
	public void change(){
		if(currentBgNum >=2){
			currentBgNum = 1;
		}else{
			currentBgNum++;
		}
		
		switch(currentBgNum){
			case 1: currentBg = bg2;
					break;
			case 2: currentBg = bg3;
					break;
		}	
	}
	
	public void setBackground(int choice){
		switch(choice){
		case 1: currentBg = bg1;
		break;
		case 2: currentBg = bg2;
		break;
		case 3: currentBg = bg3;
		break;
		}
	}
}
