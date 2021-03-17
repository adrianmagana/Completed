package com.magana.smartlist.DB;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;

import com.magana.smartlist.DB.Daos.ListItemDao;
import com.magana.smartlist.DB.Daos.SavedItemDao;
import com.magana.smartlist.DB.Models.ListItem;
import com.magana.smartlist.DB.Models.SavedItem;

@Database(entities =  { ListItem.class, SavedItem.class}, version = 6)
public abstract class SmartListDB extends RoomDatabase {
    private static  SmartListDB instance;

    public abstract SavedItemDao savedItemDao();
    public abstract ListItemDao listItemDao();

    public  static synchronized SmartListDB getInstance(Context context){
        if(instance == null){
            instance = Room.databaseBuilder(context, SmartListDB.class, "SmartList")
                    .fallbackToDestructiveMigration()
                    .build();
        }
        return instance;
    }
}
