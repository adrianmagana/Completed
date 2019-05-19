package com.example.project343;

import android.graphics.Bitmap;
import java.util.Random;

public class Icicle {
	static int instanceNum =0;
	private float xpos;
	private float ypos;
	Bitmap image;
	private int fallRate;
	private Random rand = new Random();
	
	public Icicle(float screenWidth, Bitmap b){
		instanceNum = 0;
		image = b;
		xpos = (float) ((screenWidth-image.getWidth())*(rand.nextInt(100)*.01));
		ypos = 0;
		fallRate=rand.nextInt(20)+5;
		
	}
	
	public float getX(){return xpos;}
	public float getY(){return ypos;}
	public Bitmap getBit(){return image;}
	
	public void setX(float x){ xpos = x;}
	public void setY(float y){ ypos = y;}
	
	
	public float getWidth(){
		return image.getWidth();
	}
	
	public int getFallRate(){
		return fallRate;
	}
	
	public float getHeight(){
		return image.getHeight();
	}
	
	public void fall(){
		ypos += fallRate;
	}

}
