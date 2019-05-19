package com.example.project343;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.Rect;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.view.View;
import android.view.View.OnTouchListener;

public class Surface extends Activity implements OnTouchListener{
	MyView v;
	Player p;
	Background background;
	Rect backgroundRect;
	Bitmap iciclePic;
	ArrayList<Icicle> icicles = new ArrayList<Icicle>();
	MediaPlayer backgroundMusic;
	Timer timer = new Timer();
	final double CHANGEINSPAWNRATE= .001;
	public static final String PREFS_NAME = "project343";

	double spawnRate;
	TimerTask timerTask;
	boolean survivalMode;
	boolean touchHolding = false;
	boolean left;
	Paint textPaint;
	float screenWidth;
	float screenHeight;
	boolean init = true;
	int score;
	int hiScore;
	
	int dieHealth;
	double timeAlive;
	double fastestTime;
	Timer dieTimer = new Timer();
	DecimalFormat df;
	public class Task extends TimerTask {//ran every timer iteration
	    @Override
	    public void run() {
	    	icicles.add(new Icicle(screenWidth, iciclePic));
	    	icicles.add(new Icicle(screenWidth, iciclePic));
	    	timer.schedule( new Task(), (long) (spawnRate*1000));
	    }
	}
	

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
	    hiScore = settings.getInt("hiScore", 0);
	    fastestTime = settings.getFloat("fastesttime", 0);
		survivalMode = getIntent().getExtras().getBoolean("survivalMode");
		backgroundMusic = MediaPlayer.create(this, R.raw.background_sound);
		v= new MyView(this);
		p= new Player((BitmapFactory.decodeResource(getResources(), R.drawable.player)), (BitmapFactory.decodeResource(getResources(), R.drawable.ship_left)), (BitmapFactory.decodeResource(getResources(), R.drawable.player)));
		iciclePic = BitmapFactory.decodeResource(getResources(), R.drawable.icicle2);
		background = new Background(BitmapFactory.decodeResource(getResources(), R.drawable.background), BitmapFactory.decodeResource(getResources(), R.drawable.background2), BitmapFactory.decodeResource(getResources(), R.drawable.background3));
		setContentView(v);
	}
	
	@Override
	protected void onPause() {
		super.onPause();
		v.pause();
		backgroundMusic.pause();
	}

	@Override
	protected void onResume() {
		super.onResume();
		backgroundMusic.start();
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
				//initialization section
				if(init){
					screenWidth = canvas.getWidth();
					screenHeight = canvas.getHeight();
					textPaint = new Paint();
					textPaint.setARGB(255, 0, 0, 0);
					textPaint.setTextSize(25);
					p.setX(screenWidth/2);
					p.setY(screenHeight-p.getHeight()-textPaint.getTextSize());
					dieHealth= 10;
					spawnRate = 2;
					score= 0;
					timeAlive = 0;
				    df = new DecimalFormat("#.0");
					backgroundMusic.setLooping(true);
					backgroundMusic.start();
					timer.schedule(new Task(), (long) (spawnRate*1000));
					if(!survivalMode){
						dieTimer.scheduleAtFixedRate(new TimerTask() {
							  @Override
							  public void run() {
							    timeAlive +=.1;
							  }
							}, 100, 100);
					}
					
					
					
					backgroundRect = new Rect();
					backgroundRect.set(0, 0, (int)screenWidth, (int)screenHeight);
					init = false;
				}
				
				
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
				canvas.drawBitmap(background.bg1, null, backgroundRect, new Paint());
				//canvas.drawBitmap(background.getBit(), null, backgroundRect, new Paint());
				//background.change();
				if(survivalMode){
					survive();
					canvas.drawText("Score: "+score, screenWidth/10, screenHeight-5, textPaint);
					canvas.drawText("High Score: "+ hiScore, screenWidth/10*5, screenHeight-5, textPaint);
				}else{
					die();
					canvas.drawText("Time: "+df.format(timeAlive), screenWidth/10, screenHeight-5, textPaint);
					canvas.drawText("FastestTime: "+df.format(fastestTime), screenWidth/10*5, screenHeight-5, textPaint);
					canvas.drawText("Health: "+ dieHealth, screenWidth/10*9, screenHeight-5, textPaint);
				}
				
				Icicle i;
				for (int x = 0; x < icicles.size(); x++){
					i = icicles.get(x);
					canvas.drawBitmap(i.image, i.getX(), i.getY(), new Paint());
				}
				canvas.drawBitmap(p.getPose(), p.getX(), p.getY(), new Paint());
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

	
	public void survive(){
		Icicle i;
		for (int x = 0; x < icicles.size(); x++){
			i = icicles.get(x);
			//checks for hit
			if(((p.getX() <= i.getX() && p.getX()+p.getWidth() >= i.getX()) ||
				(p.getX() <= i.getX()+i.getWidth()) && (p.getX()+p.getWidth() >= i.getX()+i.getWidth())) &&
			    (i.getY()+i.getHeight() >= p.getY())){
				Intent intent = new Intent("com.example.Project343.GameOver");
				intent.putExtra("score", score);
				intent.putExtra("survivalMode", survivalMode);
				if(score>hiScore){
					SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
				    SharedPreferences.Editor editor = settings.edit();
				    editor.putInt("hiScore", score);
				    editor.commit();
				}
				startActivity(intent);
				finish();
				
			}else{
				//checks to see if any icicle hit floor
				if(i.getY()<= (screenHeight-textPaint.getTextSize()-i.getHeight()-i.getFallRate())){
					i.fall();
				}else{
					
					score++;
					icicles.remove(x);
					if(!(spawnRate-CHANGEINSPAWNRATE <= 0)){
						spawnRate-= CHANGEINSPAWNRATE;
					}
				}
			}
		}
	}
	
	public void die(){
		Icicle i;
		for (int x = 0; x < icicles.size(); x++){
			i = icicles.get(x);
			//checks for hit
			if(((p.getX() <= i.getX() && p.getX()+p.getWidth() >= i.getX()) ||
				(p.getX() <= i.getX()+i.getWidth()) && (p.getX()+p.getWidth() >= i.getX()+i.getWidth())) &&
			    (i.getY()+i.getHeight() >= p.getY())){
				icicles.remove(x);
				dieHealth--;
			}else{
				//checks to see if any icicle hit floor
				if(i.getY()<= (screenHeight-textPaint.getTextSize()-i.getHeight()-i.getFallRate())){
					i.fall();
				}else{
					icicles.remove(x);
				}
			}
		}
		
		if(dieHealth <=0){
			Intent intent = new Intent("com.example.Project343.GameOver");
			intent.putExtra("time", timeAlive);
			intent.putExtra("survivalMode", survivalMode);
			if(timeAlive < fastestTime || fastestTime<= 0){
				SharedPreferences settings = getSharedPreferences(PREFS_NAME, 0);
			    SharedPreferences.Editor editor = settings.edit();
			    editor.putFloat("fastesttime", (float)(timeAlive));
			    editor.commit();
			}
			startActivity(intent);
			finish();
		}
	}


	@Override
	public boolean onTouchEvent(MotionEvent me) {
		
		if(me.getAction() == MotionEvent.ACTION_UP){
			touchHolding = false;
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
