package com.magana.smartlist.DB.Models;

import androidx.room.Entity;
import androidx.room.PrimaryKey;


@Entity
// item that can be added to list
public class SavedItem {
    @PrimaryKey(autoGenerate = true)
    private long id;
    private String name;
    private int priority;

    public SavedItem(){
    }

    public long getId() {
        return id;
    }
    public void setId(long id){this.id = id;}

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public int getPriority() {
        return priority;
    }
    public void setPriority(int priority) {
        this.priority = priority;
    }
}
