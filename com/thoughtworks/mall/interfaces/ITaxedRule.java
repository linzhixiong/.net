package com.thoughtworks.mall.interfaces;

import java.util.List;

/**
 * Created by IntelliJ IDEA.
 * User: twer
 * Date: 8/27/11
 * Time: 10:54 PM
 * To change this template use File | Settings | File Templates.
 */
public interface ITaxedRule {

    List<AbstractItem> apply(List<AbstractItem> items);

    AbstractItem apply(AbstractItem item);
}
