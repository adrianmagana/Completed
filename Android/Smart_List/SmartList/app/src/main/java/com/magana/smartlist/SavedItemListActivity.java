package com.magana.smartlist;

import android.content.Intent;
import android.os.Bundle;

import com.magana.smartlist.DB.Models.SavedItem;
import com.magana.smartlist.DB.SavedItemRecyclerVM;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.DividerItemDecoration;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import java.util.List;

public class SavedItemListActivity extends AppCompatActivity {
    SavedItemRecyclerVM vm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_saved_item_list);
        Toolbar toolbar = findViewById(R.id.main_toolbar);
        setSupportActionBar(toolbar);
        final RecyclerView rc = findViewById(R.id.savedItemRecycler);
        final SavedItemAdapter adapter = new SavedItemAdapter();
        rc.setAdapter(adapter);
        rc.setHasFixedSize(true);
        LinearLayoutManager manager = new LinearLayoutManager(this);
        rc.setLayoutManager(manager);
        DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rc.getContext(), manager.getOrientation());
        rc.addItemDecoration(dividerItemDecoration);
        vm = new ViewModelProvider(this).get(SavedItemRecyclerVM.class);
        vm.getSavedItems().observe(this, new Observer<List<SavedItem>>() {
            @Override
            public void onChanged(List<SavedItem> items) {
                adapter.bindList(items);
            }
        });

        //edit click
        adapter.setOnEditClickListener(new SavedItemAdapter.OnSavedItemClickListener(){
            @Override
            public void onItemClick(SavedItem item) {
                Intent intent = new Intent(getBaseContext(), EditSavedItemActivity.class);
                intent.putExtra("id", item.getId());
                intent.putExtra("name", item.getName());
                startActivity(intent);
            }
        });

        //delete click
        adapter.setOnDeleteClickListener(new SavedItemAdapter.OnSavedItemClickListener(){
            @Override
            public void onItemClick(SavedItem item) {
                deleteItem(item);
            }
        });
    }

    //confirms user is sure and deletes
    public void deleteItem(final SavedItem item) {
        final SavedItem savedItem = item;
        final String name = item.getName();
        final AlertDialog dialog = new AlertDialog.Builder(this)
                .setTitle("Delete " + name)
                .setMessage(name+ " and its associated sorting data will be removed")
                .setPositiveButton("Yes", null)
                .setNegativeButton("No", null)
                .show();
        Button positiveButton = dialog.getButton(AlertDialog.BUTTON_POSITIVE);
        positiveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(SavedItemListActivity.this, (name + " Deleted."), Toast.LENGTH_SHORT).show();
                vm.deleteSavedItem(item);
                dialog.dismiss();
            }
        });
    }

    public void onAddClick(View view) {
        EditText etName = findViewById(R.id.name);
        String name = etName.getText().toString();
        if(!name.isEmpty()){
            vm.insertSavedItem(name);
            etName.setText("");
        }
    }

    public void onReturnClick(View view) {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    @Override
    protected void onPause() { //clear focus to prevent keyboard popup
        super.onPause();
        EditText etName = findViewById(R.id.name);
        etName.clearFocus();
    }
}