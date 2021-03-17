package com.magana.smartlist.DB.Models;

        import androidx.room.Entity;
        import androidx.room.PrimaryKey;

@Entity(tableName = "ListItem")
public class ListItem { //item currently in list
    @PrimaryKey(autoGenerate = true)
    private long id;
    private long savedItemId;
    private int quantity;
    private boolean marked;

    public ListItem(){
    }
    public long getId() {
        return id;
    }
    public void setId(long id){this.id = id;}

    public long getSavedItemId() {
        return savedItemId;
    }
    public void setSavedItemId(long savedItemId) {
        this.savedItemId = savedItemId;
    }

    public int getQuantity() {
        return quantity;
    }
    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public boolean isMarked(){return marked;}
    public void setMarked(boolean marked){ this.marked = marked; }
}
