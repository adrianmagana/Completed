package com.magana.smartlist;

import androidx.appcompat.app.AppCompatActivity;
import androidx.lifecycle.ViewModelProvider;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import com.magana.smartlist.DB.SavedItemRecyclerVM;

public class EditSavedItemActivity extends AppCompatActivity {
    SavedItemRecyclerVM vm;
    long id;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit_saved_item);
        Intent intent = getIntent();
        id = intent.getLongExtra("id",0);
        EditText etName = findViewById(R.id.edit_name);
        String name = intent.getStringExtra("name");
        etName.setText(name);
        vm = new ViewModelProvider(this).get(SavedItemRecyclerVM.class);
    }

    public void onReturnClick(View view) {
        Intent intent = new Intent(this, SavedItemListActivity.class); //return to saved list
        startActivity(intent);
    }


    public void onUpdateClick(View view) {
        EditText etName = findViewById(R.id.edit_name);
        String name = etName.getText().toString();
        if(!name.isEmpty()){
            vm.updateSavedItemName(id, name);
            Intent intent = new Intent(this, SavedItemListActivity.class); //return to saved list
            startActivity(intent);
        }
    }

    @Override
    protected void onPause() { //clear focus to prevent keyboard popup
        super.onPause();
        EditText etName = findViewById(R.id.edit_name);
        etName.clearFocus();
    }
}