package com.thoughtworks.mall.items;

import com.thoughtworks.mall.interfaces.AbstractItem;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 4:56 PM
 * To change this template use File | Settings | File Templates.
 */
public class ImportedItem extends AbstractItem {
    AbstractItem basicItem;

    public ImportedItem(AbstractItem basicItem) {
        super(basicItem.isTaxedItem(), basicItem.isImportedItem(), basicItem.getOriginalPrice());
        this.basicItem = basicItem;
    }

    public ImportedItem(boolean b, boolean b1, double originalPrice) {
        super(b, b1, originalPrice);
    }

    public double getTax() {
        return basicItem != null ? basicItem.getTax() + basicItem.getOriginalPrice() * 5 / 100 : this.getOriginalPrice() * 5 / 100;
    }


}
