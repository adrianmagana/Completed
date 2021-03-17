package com.magana.smartlist;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.DividerItemDecoration;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.appwidget.AppWidgetManager;
import android.content.ComponentName;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.magana.smartlist.DB.Models.SavedItem;
import com.magana.smartlist.DB.Models.RCItem;
import com.magana.smartlist.DB.MainVM;
import com.magana.smartlist.Widget.ListWidget;

import java.util.List;

public class MainActivity extends AppCompatActivity {
    private MainVM vm;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.main_toolbar);
        setSupportActionBar(toolbar);
        final RecyclerView rc = findViewById(R.id.Rc);
        final RecyclerAdapter adapter = new RecyclerAdapter();
        rc.setAdapter(adapter);
        rc.setHasFixedSize(true);
        LinearLayoutManager manager = new LinearLayoutManager(this);
        rc.setLayoutManager(manager);
        DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(rc.getContext(), manager.getOrientation());
        rc.addItemDecoration(dividerItemDecoration);
        vm = new ViewModelProvider(this).get(MainVM.class);
        //rebinds list when change made
        vm.getRecyclerItems().observe(this, new Observer<List<RCItem>>() {
            @Override
            public void onChanged(List<RCItem> listDisplayItems) {
                adapter.bindList(listDisplayItems);
                Intent intent = new Intent(getBaseContext(), ListWidget.class);
                intent.setAction(AppWidgetManager.ACTION_APPWIDGET_UPDATE);
                AppWidgetManager manager = AppWidgetManager.getInstance(getApplication());
                int[] ids = manager.getAppWidgetIds(new ComponentName(getApplication(), ListWidget.class));
                intent.putExtra(AppWidgetManager.EXTRA_APPWIDGET_IDS, ids);
                sendBroadcast(intent);
            }
        });
        //autocomplete ddl
        final ArrayAdapter acAdapter = new ArrayAdapter(this, R.layout.autocomplete_item, R.id.ddl_textView);
        final AutoCompleteTextView acTextView = findViewById(R.id.name);
        acTextView.setAdapter(acAdapter);
        vm.getSavedItems().observe(this, new Observer<List<SavedItem>>() {
            @Override
            public void onChanged(List<SavedItem> savedItems) {
                if(acAdapter.getCount() >0){
                    acAdapter.clear();
                }
                for(SavedItem item : savedItems){
                    acAdapter.add(item.getName());
                }
            }
        });
        //onclick for item in list (creates anonymous class that implements custom interface in adapter)
        adapter.setOnItemClickListener(new RecyclerAdapter.OnItemClickListener() {
            @Override
            public void onItemClick(RCItem item) {
                if(!item.isMarked()){
                    item.setMarked(true);
                    vm.updateRCItemMark(item);
                }
            }
        });
    }

    //turns input to rcitem and return null on error
    private RCItem convertInput() {
        AutoCompleteTextView acName = findViewById(R.id.name);
        String name = acName.getText().toString();
        RCItem item = null;
        if(!name.isEmpty()) {
            EditText etQuantity = findViewById(R.id.inputQuantity);
            String strQuantity = etQuantity.getText().toString();
            int quantity = 1;
            try {
                quantity = Integer.parseInt(strQuantity); //coverts string given to int
            } catch (NumberFormatException e) {
                //assume 1 on error
            }
            item = new RCItem();
            item.setName(name);
            item.setQuantity(quantity);
            item.setMarked(false);
        }
        return item;
    }

    public void onAddClick(View view) {
        AutoCompleteTextView acName = findViewById(R.id.name);
        EditText etQuantity = findViewById(R.id.inputQuantity);
        RCItem item = convertInput();
        if(item != null){
            vm.insertRCItem(item);
            acName.setText("");
            etQuantity.setText("");
        }
    }

    public void onTrash(View view) {
        final AlertDialog dialog = new AlertDialog.Builder(this)
                .setTitle("Clear List")
                .setMessage("are you sure you want remove all items from the list?")
                .setPositiveButton("Yes", null)
                .setNegativeButton("No", null)
                .show();
        Button positiveButton = dialog.getButton(AlertDialog.BUTTON_POSITIVE);
        positiveButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Toast.makeText(MainActivity.this, ("List Cleared"), Toast.LENGTH_SHORT).show();
                vm.clearList();
                dialog.dismiss();
            }
        });
    }

    public void onItemClick(View view) {
        Intent intent = new Intent(this, SavedItemListActivity.class);
        startActivity(intent);
    }

    @Override
    protected void onPause() { //clear focus to prevent keyboard popup
        super.onPause();
        AutoCompleteTextView acName = findViewById(R.id.name);
        EditText etQuantity = findViewById(R.id.inputQuantity);
        acName.clearFocus();
        etQuantity.clearFocus();
    }
}