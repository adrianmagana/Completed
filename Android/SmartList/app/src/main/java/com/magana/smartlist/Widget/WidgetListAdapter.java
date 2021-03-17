package com.magana.smartlist.Widget;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.magana.smartlist.R;
import com.magana.smartlist.DB.Models.RCItem;

import java.util.List;

public class WidgetListAdapter extends ArrayAdapter<RCItem> {
    private Context context;

    public WidgetListAdapter(@NonNull Context context, int resource, @NonNull List<RCItem> objects) {
        super(context, resource, objects);
        this.context = context;
    }

    @NonNull
    @Override
    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup container) {
        LayoutInflater inflater = LayoutInflater.from(context);
        if (convertView == null) {
            convertView = inflater.inflate(R.layout.recycler_item, container, false);
        }
        TextView tvName = convertView.findViewById(R.id.itemName);
        TextView tvQuantity = convertView.findViewById(R.id.quantity);

        tvName.setText(getItem(position).getName());
        tvQuantity.setText(getItem(position).getQuantity());

        return convertView;


    }
}
