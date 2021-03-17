package com.magana.smartlist.DB.Repositories;

import android.app.Application;

import androidx.lifecycle.LiveData;

import com.magana.smartlist.DB.Daos.ListItemDao;
import com.magana.smartlist.DB.Daos.SavedItemDao;
import com.magana.smartlist.DB.Models.ListItem;
import com.magana.smartlist.DB.Models.SavedItem;
import com.magana.smartlist.DB.SmartListDB;

import java.util.List;

public class SavedItemRepo {
    private static final int DEFAULT_PRIORITY = 100;
    private SmartListDB db;
    private SavedItemDao dao;
    private ListItemDao liDao;

    public SavedItemRepo(Application app){
        db = SmartListDB.getInstance(app);
        dao = db.savedItemDao();
        liDao = db.listItemDao();
    }
    public SavedItem find(String name){
        return dao.find(name);
    }

    public LiveData<List<SavedItem>> getAll(){ return dao.getAll();}

    public void insert(SavedItem item){
        new InsertSavedItemThread(item, dao).start();
    }

    public void insert(String item){
        SavedItem si = new SavedItem();
        si.setName(item);
        si.setPriority(DEFAULT_PRIORITY);
        new InsertSavedItemThread(si, dao).start();
    }

    public void updateName(long id, String name){
        new UpdateNameTread(id, name, dao).start();
    }

    public void delete(SavedItem item){ new DeleteSavedItemTread(item, dao, liDao).start();}

    //                              Thread classes

    private static class InsertSavedItemThread extends Thread{
        private SavedItemDao dao;
        private SavedItem item;

        private InsertSavedItemThread(SavedItem si, SavedItemDao siDao) {
            item = si;
            dao = siDao;
        }

        public void run(){
            SavedItem existingItem = dao.find(item.getName());
            if(existingItem == null){
                dao.insert(item);
            }
        }
    }

    private static class UpdateNameTread extends Thread{
        private SavedItemDao dao;
        long id;
        String name;


        private UpdateNameTread(long id, String name, SavedItemDao  siDao){
            dao = siDao;
            this.id = id;
            this.name = name;
        }

        public void run(){
            SavedItem item = dao.find(name);
            if(name != "" && item == null){
                dao.updateName(id, name);
            }
        }
    }

    private static class DeleteSavedItemTread extends Thread{
        private SavedItemDao dao;
        private ListItemDao liDao;
        private SavedItem item;

        private DeleteSavedItemTread(SavedItem siItem, SavedItemDao  savedItemDao, ListItemDao listItemDao){
            dao = savedItemDao;
            liDao = listItemDao;
            item = siItem;
        }

        public void run(){
            ListItem listItem= liDao.getListItemBySavedId(item.getId());
            if(listItem != null){
                liDao.delete(listItem);
            }
            dao.delete(item);
        }
    }

}
