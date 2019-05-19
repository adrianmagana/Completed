package com.example.project343;

import android.graphics.Bitmap;

public class Player {
	private float xpos;
	private float ypos;
	Bitmap still;
	Bitmap left;
	Bitmap right;
	private Bitmap currentPose;
	
	
	public Player(Bitmap s, Bitmap l, Bitmap r){
		still = s;
		left = l;
		right = r;
		currentPose = s;
	}
	
	public float getX(){return xpos;}
	public float getY(){return ypos;}
	public Bitmap getPose(){return currentPose;}
	
	public void setX(float x){ xpos = x;}
	public void setY(float y){ ypos = y;}
	
	public void setPose(int choice){
		switch(choice){
		case 1: currentPose = still;
		break;
		case 2: currentPose = left;
		break;
		case 3: currentPose = right;
		break;
		}
	}
	
	public void left(){
		currentPose = left;
		xpos-=5;
	}
	public void right(){
		currentPose = right;
		xpos+=5;
	}
	
	public float getWidth(){
		return still.getWidth();
	}
	
	public float getHeight(){
		return still.getHeight();
	}

}
