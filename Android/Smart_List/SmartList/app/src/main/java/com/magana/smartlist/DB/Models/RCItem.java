package com.magana.smartlist.DB.Models;

import androidx.room.ColumnInfo;
//item in recycler view built from other entities
public class RCItem {
    private String name;
    private int quantity;
    private boolean marked;
    @ColumnInfo(name ="id") //ensures ids get assigned to correct location
    private long listItemId;
    @ColumnInfo(name ="savedItemId") //listitem's saveditemId
    private long savedItemId;

    public RCItem(){
    }

    public String getName() {
        return name;
    }
    public void setName(String itemName) {
        this.name = itemName;
    }

    public int getQuantity() {
        return quantity;
    }
    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public boolean isMarked() { return marked; }
    public void setMarked(boolean marked) {
        this.marked = marked;
    }

    public long getListItemId() {
        return listItemId;
    }
    public void setListItemId(long listItemId) {
        this.listItemId = listItemId;
    }

    public long getSavedItemId() {
        return savedItemId;
    }
    public void setSavedItemId(long savedItemId) {
        this.savedItemId = savedItemId;
    }

}
