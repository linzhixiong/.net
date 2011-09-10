package com.thoughtworks.mall.client;

import com.thoughtworks.mall.interfaces.AbstractItem;
import com.thoughtworks.mall.interfaces.ITaxedRule;
import com.thoughtworks.mall.items.BasicItem;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 11:38 PM
 * To change this template use File | Settings | File Templates.
 */
public class program {

    public static void main(String[] args) {
        ITaxedRule taxedRule;
        try {
            taxedRule = (ITaxedRule) Class.forName("com.thoughtworks.mall.items.TaxedRule").newInstance();
        } catch (Exception e) {
            taxedRule = null;
        }

        List<AbstractItem> listOne = new ArrayList<AbstractItem>();
        listOne.add(new BasicItem(false, false, 12.49));
        listOne.add(new BasicItem(true, false, 14.99));
        listOne.add(new BasicItem(false, false, 0.85));
        printPrice(taxedRule.apply(listOne));

        List<AbstractItem> listTwo = new ArrayList<AbstractItem>();
        listTwo.add(new BasicItem(false, true, 10.00));
        listTwo.add(new BasicItem(true, true, 47.50));
        printPrice(taxedRule.apply(listTwo));

        List<AbstractItem> listThree = new ArrayList<AbstractItem>();
        listThree.add(new BasicItem(true, true, 27.99));
        listThree.add(new BasicItem(true, false, 18.99));
        listThree.add(new BasicItem(false, false, 9.75));
        listThree.add(new BasicItem(false, true, 11.25));
        printPrice(taxedRule.apply(listThree));
    }

    public static void printPrice(List<AbstractItem> items) {
        double totalPrice = 0.00;
        double taxes = 0.00;
        for (AbstractItem item : items) {
            System.out.println("1 " + item.getItemName() + ":" + item.getOriginalPrice());
            totalPrice += item.getAfterTaxedPrice();
            taxes += item.getTax();
        }
        System.out.println("Sale texes:" + Math.ceil(taxes * 20) / 20);
        System.out.println("Total:" + round(totalPrice, 2, BigDecimal.ROUND_HALF_UP));
    }

    public static double round(double value, int scale, int roundingMode) {
        BigDecimal bd = new BigDecimal(value);
        bd = bd.setScale(scale, roundingMode);
        double d = bd.doubleValue();
        bd = null;
        return d;
    }

}
