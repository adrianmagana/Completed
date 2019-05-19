package com.example.project343;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

public class MainMenu extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.main_menu);
		Button survive = (Button) findViewById(R.id.survive);
		Button die = (Button) findViewById(R.id.die);
		
		survive.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View arg0) {
				Intent intent = new Intent("com.example.Project343.Surface");
				intent.putExtra("survivalMode", true);
				startActivity(intent);
				finish();
				
			}
		});
		
		die.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View arg0) {
				Intent intent = new Intent("com.example.Project343.Surface");
				intent.putExtra("survivalMode", false);
				startActivity(intent);
				finish();
				
			}
		});
	}
}
