package com.magana.smartlist.DB;

import android.app.Application;

import androidx.annotation.NonNull;
import androidx.lifecycle.AndroidViewModel;
import androidx.lifecycle.LiveData;

import com.magana.smartlist.DB.Models.SavedItem;
import com.magana.smartlist.DB.Repositories.SavedItemRepo;

import java.util.List;

public class SavedItemRecyclerVM extends AndroidViewModel {
    private SavedItemRepo repo;

    public SavedItemRecyclerVM(@NonNull Application application) {
        super(application);
        repo = new SavedItemRepo(application);
    }

    public LiveData<List<SavedItem>> getSavedItems(){
        return repo.getAll();
    }

    public void updateSavedItemName(long id, String name){
        String capitalized = capitalizeWords(name);
        repo.updateName(id, capitalized);
    }

    public void insertSavedItem(String name){
        String capitalized = capitalizeWords(name);
        repo.insert(capitalized);
    }

    public void deleteSavedItem(SavedItem item){
        repo.delete(item);
    }

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
