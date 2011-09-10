package com.thoughtworks.mall.items;

import com.thoughtworks.mall.interfaces.AbstractItem;
import com.thoughtworks.mall.interfaces.ITaxedRule;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 5:59 PM
 * To change this template use File | Settings | File Templates.
 */
public class TaxedRule implements ITaxedRule {

    public List<AbstractItem> apply(List<AbstractItem> items) {
        List<AbstractItem> exactItems = new ArrayList<AbstractItem>();
        for (AbstractItem item : items) {
            exactItems.add(apply(item));
        }
        return exactItems;
    }

    public AbstractItem apply(AbstractItem item) {
        item = item.isTaxedIt|em() ? item = new TaxedItem(item) : item;
        item = item.isImportedItem() ? item = new ImportedItem(item) : item;
        return item;  //To change body of implemented methods use File | Settings | File Templates.
    }
}
