package com.magana.smartlist.Widget;

import android.appwidget.AppWidgetManager;
import android.content.Context;
import android.content.Intent;
import android.view.View;
import android.widget.RemoteViews;
import android.widget.RemoteViewsService;

import com.magana.smartlist.DB.Daos.ListItemDao;
import com.magana.smartlist.DB.Models.RCItem;
import com.magana.smartlist.DB.SmartListDB;
import com.magana.smartlist.R;

import java.util.ArrayList;
import java.util.List;

public class WidgetService extends RemoteViewsService {
    @Override
    public RemoteViewsFactory onGetViewFactory(Intent intent) {
        return new WidgetItemFactory(getApplicationContext(), intent);
    }

    class WidgetItemFactory implements RemoteViewsFactory{
        private Context context;
        private int widgetId;
        private SmartListDB db;
        private ListItemDao dao;
        private List<RCItem> dataset;
        public WidgetItemFactory(Context context, Intent intent){
            this.context = context;
            widgetId = intent.getIntExtra(AppWidgetManager.EXTRA_APPWIDGET_ID, AppWidgetManager.INVALID_APPWIDGET_ID);
            dataset = new ArrayList<RCItem>();
        }

        @Override
        public void onCreate() {
        }

        @Override
        public void onDataSetChanged() {
            db = SmartListDB.getInstance(context);
            dao = db.listItemDao();
            dataset =  dao.getAllAsRcStandard(); //get as list instead of livedata because its already on individual thread
        }

        @Override
        public void onDestroy() {
        }

        @Override
        public int getCount() {
            return dataset.size();
        }

        @Override
        public RemoteViews getViewAt(int position) {
            RCItem item = dataset.get(position);
            RemoteViews views = new RemoteViews(context.getPackageName(), R.layout.widget_item);
            views.setTextViewText(R.id.widget_name, item.getName());
            views.setTextViewText(R.id.widget_quantity, Integer.toString(item.getQuantity()));
            if(item.isMarked()){ //strikes through item if its been selected
                views.setViewVisibility(R.id.widget_strike, View.VISIBLE);
            } else{
                views.setViewVisibility(R.id.widget_strike, View.INVISIBLE);
            }
            return views;
        }

        @Override
        public RemoteViews getLoadingView() {
            return null;
        }

        @Override
        public int getViewTypeCount() {
            return 1;
        }

        @Override
        public long getItemId(int position) {
            return position;
        }

        @Override
        public boolean hasStableIds() {
            return true;
        }
    }
}
