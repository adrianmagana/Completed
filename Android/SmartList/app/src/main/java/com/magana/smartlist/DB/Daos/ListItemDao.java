package com.magana.smartlist.DB.Daos;

import androidx.lifecycle.LiveData;
import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;
import androidx.room.Delete;

import com.magana.smartlist.DB.Models.ListItem;
import com.magana.smartlist.DB.Models.RCItem;

import java.util.List;

@Dao
public interface ListItemDao {

    @Insert
    public void insert(ListItem item);

    @Query("Select * from ListItem")
    public LiveData<List<ListItem>> getAll();

    @Query("Select * from listitem where savedItemId =  :id limit 1")
    public ListItem getListItemBySavedId(long id);

    @Query("Select si.name, li.quantity, li.marked, li.id, li.savedItemId " +
            "from ListItem as li " +
            "join SavedItem as si " +
            "on li.savedItemId = si.id " +
            "order by si.priority")
    public LiveData<List<RCItem>> getAllAsRcItem();

    @Query("Select si.name, li.quantity, li.marked, li.id, li.savedItemId " +
            "from ListItem as li " +
            "join SavedItem as si " +
            "on li.savedItemId = si.id " +
            "order by si.priority")
    public List<RCItem> getAllAsRcStandard();

    @Update
    public  void update(ListItem item);

    @Query("update ListItem " +
            "set marked = :mark " +
            "where id = :id")
    public void updateMark(long id, boolean mark);

    @Delete
    public void delete(ListItem item);

    @Query("delete from ListItem")
    public void deleteAll();
}