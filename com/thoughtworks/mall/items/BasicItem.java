package com.thoughtworks.mall.items;

import com.thoughtworks.mall.interfaces.AbstractItem;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 3:58 PM
 * To change this template use File | Settings | File Templates.
 */
public class BasicItem extends AbstractItem {
    public BasicItem(boolean isTaxedItem, boolean isImportedItem, double originalPrice) {
        super(isTaxedItem, isImportedItem, originalPrice);
    }



    public double getTax() {
        return 0.00;
    }
}
