package com.magana.smartlist.DB.Repositories;

import android.app.Application;
import android.content.Context;
import android.content.SharedPreferences;

import androidx.lifecycle.LiveData;

import com.magana.smartlist.DB.Daos.ListItemDao;
import com.magana.smartlist.DB.Daos.SavedItemDao;
import com.magana.smartlist.DB.Models.ListItem;
import com.magana.smartlist.DB.Models.SavedItem;
import com.magana.smartlist.DB.Models.RCItem;
import com.magana.smartlist.DB.SmartListDB;

import java.util.List;

public class ListItemRepo {
    private static final String SMARTLIST_MAIN_KEY = "smartlist_main";
    private static final String PRIORITY_INCREMENT_KEY = "increment";
    private static final int ERROR_CODE = -999;
    private static final int STARTING_PRIORITY = -7;
    private static final int INCREMENT_AMOUNT = 1;
    private static final int DEFAULT_PRIORITY = 100;
    private static SharedPreferences pref;
    private ListItemDao dao;
    private SmartListDB db;

    public ListItemRepo(Application app){
        pref = app.getBaseContext().getSharedPreferences(SMARTLIST_MAIN_KEY,Context.MODE_PRIVATE);
        int priority = pref.getInt(PRIORITY_INCREMENT_KEY, ERROR_CODE);
        if(priority == ERROR_CODE){
            SharedPreferences.Editor editor = pref.edit();
            editor.putInt(PRIORITY_INCREMENT_KEY, STARTING_PRIORITY);
            editor.apply();
        }

        db = SmartListDB.getInstance(app);
        dao = db.listItemDao();
    }

    public LiveData<List<RCItem>> getRCItems(){
        return dao.getAllAsRcItem();
    }

    //add RCItem to list and saved items
    public void insertRCItem(RCItem item){
        new InsertAsRCItemThread(item, dao, db.savedItemDao()).start();
    }

    public void updateListItemMark(RCItem item){
        int increment = pref.getInt(PRIORITY_INCREMENT_KEY, ERROR_CODE);
        //updates increment for next use
        SharedPreferences.Editor editor = pref.edit();
        editor.putInt(PRIORITY_INCREMENT_KEY, increment + INCREMENT_AMOUNT);
        editor.apply();
        //marks the item and applies its new priority
        new updateListItemMark(item, increment, dao, db.savedItemDao()).start();
    }

    public void clearList(){
        SharedPreferences.Editor editor = pref.edit();
        editor.putInt(PRIORITY_INCREMENT_KEY, STARTING_PRIORITY);
        editor.apply();
        new ClearListThread(dao).start();
    }

    //                              Thread classes

    //breaks RCItem into entity objects and insert them into each table in a new thread
    private static class InsertAsRCItemThread extends Thread{
        private ListItemDao listItemDao;
        private SavedItemDao savedItemDao;
        private RCItem rcItem;

        private InsertAsRCItemThread(RCItem item, ListItemDao liDAO, SavedItemDao siDAO) {
            rcItem = item;
            listItemDao = liDAO;
            savedItemDao = siDAO;
        }

        public void run(){
            //grabs savedItemId if it exist
            SavedItem savedItem = savedItemDao.find(rcItem.getName());

            long savedItemId;
            //adds item to list and create associated savedItem if it doesn't exist
            if(savedItem == null){
                //new savedItem
                SavedItem si = new SavedItem();
                si.setName(rcItem.getName());
                si.setPriority(DEFAULT_PRIORITY);
                savedItemId = savedItemDao.insert(si);
            }else{
                savedItemId = savedItem.getId();
            }

            ListItem li = listItemDao.getListItemBySavedId(savedItemId);
            if(li == null){
                li = new ListItem();
                li.setSavedItemId(savedItemId);
                li.setQuantity(rcItem.getQuantity());
                li.setMarked(false);
                listItemDao.insert(li);
            }
        }
    }

    private static class updateListItemMark extends Thread{
        private ListItemDao listItemDao;
        private SavedItemDao savedItemDao;
        private int inc;
        private RCItem item;

        private updateListItemMark(RCItem rcItem, int increment, ListItemDao liDAO, SavedItemDao siDAO){
            listItemDao = liDAO;
            item = rcItem;
            savedItemDao = siDAO;
            inc = increment;
        }

        public void run(){
            if(item.isMarked()){
                listItemDao.updateMark(item.getListItemId(), item.isMarked());
                SavedItem savedItem = savedItemDao.getById(item.getSavedItemId());
                int priority = savedItem.getPriority() + inc;
                if(priority < 0){ //limits highest priority to 0
                    priority = 0;
                }
                savedItemDao.updatePriority(item.getSavedItemId(), priority);
            }
        }
    }

    private static class ClearListThread extends Thread{
        ListItemDao listItemDao;

        private ClearListThread(ListItemDao dao){
            listItemDao = dao;
        }

        public void run(){
            listItemDao.deleteAll();
        }
    }
}
