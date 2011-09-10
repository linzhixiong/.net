package com.thoughtworks.mall.test;

import com.thoughtworks.mall.interfaces.AbstractItem;
import com.thoughtworks.mall.items.BasicItem;
import com.thoughtworks.mall.items.ImportedItem;
import com.thoughtworks.mall.items.TaxedItem;
import com.thoughtworks.mall.items.TaxedRule;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import java.lang.reflect.Type;

import static junit.framework.Assert.assertEquals;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 11:17 PM
 * To change this template use File | Settings | File Templates.
 */
public class TaxedRuleTest {
    TaxedRule rule;

    @Before
    public void setUp() throws Exception {
        rule = new TaxedRule();
    }

    @After
    public void tearDown() throws Exception {

    }

    @Test
    public void testApplyWithBasicItem() throws Exception {
        AbstractItem item = new BasicItem(false, false, 100);
        item = rule.apply(item);
        Class exceptType = BasicItem.class;
        assertEquals(exceptType, item.getClass());

    }

    @Test
    public void testApplyWithTaxedItem() throws Exception {
        AbstractItem item = new BasicItem(true, false, 1000);
        item = rule.apply(item);
        Type exceptType = TaxedItem.class;
        assertEquals(exceptType, item.getClass());
    }

    @Test
    public void testApplyWithImportedItem() throws Exception {
        AbstractItem item = new BasicItem(false, true, 1000);
        item = rule.apply(item);
        Type exceptType = ImportedItem.class;
        assertEquals(exceptType, item.getClass());
    }
}
