package com.thoughtworks.mall.test;

import com.thoughtworks.mall.items.ImportedItem;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static junit.framework.Assert.assertEquals;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 4:58 PM
 * To change this template use File | Settings | File Templates.
 */
public class ImportedItemTest {
    ImportedItem item;

    @Before
    public void setUp() throws Exception {
        item = new ImportedItem(true,true ,10.00);
    }

    @After
    public void tearDown() throws Exception {

    }

    @Test
    public void testCalculate() throws Exception {
        double tax = item.getTax();
        assertEquals(0.50, tax);
    }

    @Test
    public void testGetAfterTaxedPrice() throws Exception {

        double afterTaxedPrice = item.getAfterTaxedPrice();
        assertEquals(10.50, afterTaxedPrice);
    }

}
