package com.thoughtworks.mall.test;
import com.thoughtworks.mall.items.BasicItem;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import static junit.framework.Assert.assertEquals;


/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 3:59 PM
 * To change this template use File | Settings | File Templates.
 */
public class BasicItemTest {
    BasicItem item;

    @Before
    public void setUp() throws Exception {
        item = new BasicItem(false, false, 10.00);
    }

    @After
    public void tearDown() throws Exception {
        item = null;
    }

    @Test
    public void calculateTest() {
        double tax = item.getTax();
        assertEquals(0.00, tax);
    }

    @Test
    public void testGetAfterTaxedPrice() throws Exception {
        double afterTaxedPrice = item.getAfterTaxedPrice();
        assertEquals(10.00, afterTaxedPrice);
    }
}
