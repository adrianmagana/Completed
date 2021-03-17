package com.magana.smartlist;

import android.media.Image;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.magana.smartlist.DB.Models.SavedItem;

import java.util.ArrayList;
import java.util.List;


public class SavedItemAdapter extends RecyclerView.Adapter<SavedItemAdapter.SavedItemViewHolder> {
    private List<SavedItem> dataSet;
    OnSavedItemClickListener editClickListener;
    OnSavedItemClickListener deleteClickListener;

    public SavedItemAdapter() {
        dataSet = new ArrayList<SavedItem>();
    }

    public SavedItemAdapter(List<SavedItem> dataSet) {
        this.dataSet = dataSet;
    }

    public void setOnEditClickListener(OnSavedItemClickListener listener) {
        this.editClickListener = listener;
    }

    public void setOnDeleteClickListener(OnSavedItemClickListener listener) {
        this.deleteClickListener = listener;
    }

    public int getItemCount() {
        return dataSet.size();
    }

    public void bindList(List<SavedItem> items) {
        dataSet = items;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public SavedItemViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.saved_item_recylcer_item, parent, false);
        return new SavedItemViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull SavedItemViewHolder holder, int position) {
        holder.name.setText(dataSet.get(position).getName());
    }

    //          ViewHolder inner class
    public class SavedItemViewHolder extends RecyclerView.ViewHolder {
        public TextView name;

        public SavedItemViewHolder(View v) {
            super(v);
            name = v.findViewById(R.id.itemName);
            ImageView edit = v.findViewById(R.id.edit);
            edit.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    int position = getAdapterPosition();
                    if (editClickListener != null && position != RecyclerView.NO_POSITION)
                        editClickListener.onItemClick(dataSet.get(position));
                }
            });

            TextView delete = v.findViewById(R.id.delete);
            delete.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    int position = getAdapterPosition();
                    if (deleteClickListener != null && position != RecyclerView.NO_POSITION)
                        deleteClickListener.onItemClick(dataSet.get(position));
                }
            });
        }

    }
    public interface OnSavedItemClickListener {
        void onItemClick(SavedItem item);
    }
}