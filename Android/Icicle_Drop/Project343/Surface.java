package com.example.project343;

import android.app.Activity;
import android.content.Context;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.view.View.OnTouchListener;

public class Surface extends Activity implements OnTouchListener{
	MyView v;
	Player p;
	Icicle icicles[];
	boolean touchHolding = false;
	boolean left;
	int Score;
	Paint textPaint;
	
	float screenWidth;
	float screenHeight;
	boolean init = true;
	
	

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		v= new MyView(this);
		p= new Player((BitmapFactory.decodeResource(getResources(), R.drawable.player_still)), (BitmapFactory.decodeResource(getResources(), R.drawable.player_left)), (BitmapFactory.decodeResource(getResources(), R.drawable.player_right)));
		
		v.setOnTouchListener(this);
		setContentView(v);
	}
	
	@Override
	protected void onPause() {
		super.onPause();
		v.pause();
	}

	@Override
	protected void onResume() {
		super.onResume();
		v.resume();
	}

	
	
	
	
	public class MyView extends SurfaceView implements Runnable{
		Thread t = null;
		SurfaceHolder holder;
		boolean isOk = false;
		public MyView(Context context) {
			super(context);
			holder = getHolder();
		}

		@Override
		public void run() {
			
			while(isOk==true){
				
				if(!holder.getSurface().isValid()){
					continue;
				}
				Canvas canvas=  holder.lockCanvas();
				if(init){
					screenWidth = canvas.getWidth();
					screenHeight = canvas.getHeight();
					textPaint = new Paint();
					textPaint.setARGB(255, 0, 0, 0);
					textPaint.setTextSize(25);
					p.setX(screenWidth/2);
					p.setY(screenHeight-p.getHeight()-textPaint.getTextSize());
					init = false;
				}
				canvas.drawARGB(255, 255, 255, 255);
				if(touchHolding){
					if(left){
						if(p.getX()>=0){
							p.left();
						}
					}else{
						if(p.getX()<=screenWidth-p.getWidth()){
							p.right();
						}
					}
				}
				canvas.drawBitmap(p.getPose(), p.getX(), p.getY(), new Paint());
				canvas.drawText("Score: ", screenWidth/10, screenHeight-5, textPaint);
				canvas.drawLine(0, screenHeight-textPaint.getTextSize(), screenWidth, screenHeight-textPaint.getTextSize()+5,  new Paint());
				holder.unlockCanvasAndPost(canvas);
			}
	}
		
		public void pause(){
			isOk = false;
			while(true){
				try{
					t.join();
				}catch(InterruptedException e){
					e.printStackTrace();
				}
				break;
			}
			t= null;
			
		}
		public void resume(){
			isOk = true;
			t = new Thread(this);
			t.start();
			
		}
		
	}


	@Override
	public boolean onTouchEvent(MotionEvent me) {
		
		if(me.getAction() == me.ACTION_UP){
			touchHolding = false;
			p.setPose(1);
		}else{
			if(me.getX() < v.getWidth()/2){
				left = true;
				touchHolding = true;
			}else{
					left = false;
					touchHolding = true;
			}
		}
		
		return super.onTouchEvent(me);
	}

	@Override
	public boolean onTouch(View v, MotionEvent event) {
		return false;
	}

}
