package com.thoughtworks.mall.interfaces;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 5:53 PM
 * To change this template use File | Settings | File Templates.
 */
public abstract class AbstractItem {
    private double originalPrice;
    private boolean isTaxedItem;
    private boolean isImportedItem;
    private String itemName;

    protected AbstractItem(boolean isTaxedItem, boolean isImportedItem, double originalPrice) {
        this(isTaxedItem, isImportedItem, originalPrice, "have no name");
    }

    public AbstractItem(boolean isTaxedItem, boolean isImportedItem, double originalPrice, String itemName) {
        this.originalPrice = originalPrice;
        this.isTaxedItem = isTaxedItem;
        this.isImportedItem = isImportedItem;
        this.itemName = itemName;
    }

    public double getAfterTaxedPrice() {
        return this.originalPrice + Math.ceil(getTax() * 20) / 20;

    }

    public abstract double getTax();

    public boolean isImportedItem() {
        return isImportedItem;
    }

    public boolean isTaxedItem() {
        return isTaxedItem;
    }

    public double getOriginalPrice() {
        return originalPrice;
    }

    public String getItemName() {
        return itemName;
    }
}
