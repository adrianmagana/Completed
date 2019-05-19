package com.example.project343;

import android.graphics.Bitmap;
import java.util.Random;

public class Icicle {
	private float xpos;
	private float ypos;
	Bitmap still;
	int fallrate = 10;
	Random rand = new Random();
	
	public Icicle(int x, int y, Bitmap b){
		xpos = x;
		ypos = y;
		still = b;
		
	}
	
	public float getX(){return xpos;}
	public float getY(){return ypos;}
	public Bitmap getBit(){return still;}
	
	public void setX(float x){ xpos = x;}
	public void setY(float y){ ypos = y;}
	
	
	public float getWidth(){
		return still.getWidth();
	}
	
	public float getHeight(){
		return still.getHeight();
	}

}
