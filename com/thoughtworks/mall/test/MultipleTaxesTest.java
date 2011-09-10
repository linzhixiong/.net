package com.thoughtworks.mall.test;


import com.thoughtworks.mall.interfaces.AbstractItem;
import com.thoughtworks.mall.items.BasicItem;
import com.thoughtworks.mall.items.ImportedItem;
import com.thoughtworks.mall.items.TaxedItem;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static junit.framework.Assert.assertEquals;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 9:12 PM
 * To change this template use File | Settings | File Templates.
 */
public class MultipleTaxesTest {
    AbstractItem item;

    @Before
    public void setUp() throws Exception {

    }

    @After
    public void tearDown() throws Exception {

    }

    @Test
    public void TestMultipleTaxedItem() {
        item = new BasicItem(true, true, 47.50);
        item = new TaxedItem(item);
        item = new ImportedItem(item);
        double tax = item.getAfterTaxedPrice();
        assertEquals(54.65, tax);
    }
}
