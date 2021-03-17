package com.magana.smartlist.DB.Daos;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.OnConflictStrategy;
import androidx.room.Query;
import androidx.room.Update;

import com.magana.smartlist.DB.Models.SavedItem;

import java.util.List;

@Dao
public interface SavedItemDao {
    @Insert(onConflict = OnConflictStrategy.REPLACE)
    public long insert(SavedItem item);

    @Query("select * from saveditem where id = :id")
    public SavedItem getById(long id);

    @Query("Select * from SavedItem")
    public LiveData<List<SavedItem>> getAll();

    @Query("select * from Saveditem where name like :n")
    public SavedItem find(String n);

    @Update
    public  void update(SavedItem item);

    @Query("update Saveditem set priority = :priority where id = :id")
    public void updatePriority(long id, int priority);

    @Query("update Saveditem " +
            "set name = :name " +
            "where id = :id")
    public void updateName(long id, String name);

    @Delete
    public void delete(SavedItem item);

    @Query("delete from Saveditem")
    public void deleteAll();
}
