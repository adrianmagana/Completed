package com.magana.smartlist.DB;

import android.app.Application;

import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;

import com.magana.smartlist.DB.Models.ListItem;
import com.magana.smartlist.DB.Models.RCItem;
import com.magana.smartlist.DB.Models.SavedItem;
import com.magana.smartlist.DB.Repositories.ListItemRepo;
import com.magana.smartlist.DB.Repositories.SavedItemRepo;

import java.util.List;

public class MainVM extends AndroidViewModel {
    private ListItemRepo listItemRepo;
    private SavedItemRepo savedItemRepo;
    private LiveData<List<RCItem>> rcItems;

    public MainVM(Application application){
        super(application);
        listItemRepo = new ListItemRepo(application);
        savedItemRepo = new SavedItemRepo(application);
        rcItems = listItemRepo.getRCItems();
    }

    public LiveData<List<RCItem>> getRecyclerItems(){
        return rcItems;
    }

    public LiveData<List<SavedItem>> getSavedItems(){
        return savedItemRepo.getAll();
    }

    public void insertRCItem(RCItem item){
        String capitalized = capitalizeWords(item.getName());
        item.setName(capitalized);
        listItemRepo.insertRCItem(item);
    }

    public void updateRCItemMark(RCItem item) {listItemRepo.updateListItemMark(item);}

    public void clearList(){listItemRepo.clearList();}

    //capitalize each word and removes extra spaces
    private String capitalizeWords(String str){
        String[] words = str.split("\\s+");
        String capped = "";
        for(int i=0; i < words.length; i++){
            String word = words[i];
            capped += word.substring(0, 1).toUpperCase() + word.substring(1).toLowerCase();//sets first letter cap of word and concats to form original
            if(!(i+1 == words.length)){//adds space back if not last word
                capped += " ";
            }
        }
        return capped;
    }
}
