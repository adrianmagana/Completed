package com.magana.smartlist;


import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import com.magana.smartlist.DB.Models.RCItem;

import java.util.ArrayList;
import java.util.List;

public class RecyclerAdapter extends RecyclerView.Adapter<RecyclerAdapter.ViewHolder> {
    private List<RCItem> dataSet;
    OnItemClickListener listener;

    public RecyclerAdapter(){
        dataSet = new ArrayList<RCItem>();
    }

    public RecyclerAdapter(List<RCItem> data){
        dataSet = data;
    }

    public void setOnItemClickListener(OnItemClickListener listener){
        this.listener = listener;
    }

    @Override
    public int getItemCount() {
        return dataSet.size();
    }

    public void add(RCItem item) {
        dataSet.add(item);
        notifyDataSetChanged();
    }

    public void bindList(List<RCItem> data){
        dataSet = data;
        notifyDataSetChanged();
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.recycler_item, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, final int position) {
        holder.name.setText(dataSet.get(position).getName());
        int q = dataSet.get(position).getQuantity();
        holder.quantity.setText(Integer.toString(q));

        if(dataSet.get(position).isMarked()){
            //displays strike line
            holder.strikeThrough.setVisibility(View.VISIBLE);
        }else{
            //hides strike line
            holder.strikeThrough.setVisibility(View.GONE);
        }
    }


    public class ViewHolder extends RecyclerView.ViewHolder {
        public TextView name;
        public TextView quantity;
        public View strikeThrough;
        public ViewHolder(View v) {
            super(v);
            name = v.findViewById(R.id.itemName);
            quantity = v.findViewById(R.id.quantity);
            strikeThrough = v.findViewById(R.id.strike);
            v.setOnLongClickListener(new View.OnLongClickListener() {
                @Override
                public boolean onLongClick(View view) {
                    int position = getAdapterPosition();
                    if(listener != null && position != RecyclerView.NO_POSITION)
                    listener.onItemClick(dataSet.get(position));
                    return true;
                }
            });
        }
    }

    public interface OnItemClickListener{
        void onItemClick(RCItem item);
    }
}
