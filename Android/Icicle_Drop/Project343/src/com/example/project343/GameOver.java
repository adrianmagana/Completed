package com.example.project343;

import java.text.DecimalFormat;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class GameOver extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.game_over);
		
		boolean survivalMode = getIntent().getExtras().getBoolean("survivalMode");
		Button replay = (Button) findViewById(R.id.replay);
		Button mainMenu = (Button) findViewById(R.id.MainMenu);
		TextView score = (TextView) findViewById(R.id.score);
		if(survivalMode){
		score.setText("score: "+ getIntent().getExtras().getInt("score"));
		}else{
			DecimalFormat df = new DecimalFormat("#.0");
			score.setText("Time: "+ df.format(getIntent().getExtras().getDouble("time")));
		}
		
		replay.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View arg0) {
				Intent intent = new Intent("com.example.Project343.Surface");
				intent.putExtra("survivalMode", getIntent().getExtras().getBoolean("survivalMode"));
				startActivity(intent);
				finish();
				
			}
		});
		
		mainMenu.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View arg0) {
				Intent intent = new Intent("com.example.Project343.MainMenu");
				startActivity(intent);
				finish();
				
			}
		});
	}
}
