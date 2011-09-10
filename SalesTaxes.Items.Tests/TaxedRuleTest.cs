using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Items.Enums;
using NUnit.Framework;
using SalesTaxes.Interface;

namespace SalesTaxes.Items.Tests
{
    [TestFixture]
    public class TaxedRuleTest
    {

        TaxedRule rule;
        [SetUp]
        public void SetUp()
        {
            rule = new TaxedRule();
        }

        [Test]
        public void ApplyTest_Three()
        {
            AbstractItem item = new Item(Category.BOOK, true, 11.28m);
            Type resultType = typeof(ImportedItem);
            item = rule.Apply(item);
            Assert.IsNotNull(item);
            Assert.AreEqual(resultType, item.GetType());
        }
        [Test]
        public void ApplyTest_One()
        {
            AbstractItem item = new Item(Category.FOOD, false, 11.28m);
            Type resultType = typeof(Item);
            item = rule.Apply(item);
            Assert.IsNotNull(item);
            Assert.AreEqual(resultType, item.GetType());
        }
        [Test]
        public void ApplyTest_Two()
        {
            AbstractItem item = new Item(Category.OTHERS, false, 11.28m);
            Type resultType = typeof(TaxedItem);
            item = rule.Apply(item);
            Assert.IsNotNull(item);
            Assert.AreEqual(resultType, item.GetType());
        }
        [Test]
        public void ApplyTest_Four()
        {
            AbstractItem item = new Item(Category.MEDICAL, true, 11.28m);
            Type resultType = typeof(ImportedItem);
            item = rule.Apply(item);
            Assert.IsNotNull(item);
            Assert.AreEqual(resultType, item.GetType());
        }

        [Test]
        public void ApplyTest_Items()
        {
            AbstractItem item = new Item(Category.BOOK, true, 11.28m);
            AbstractItem anotherItem = new Item(Category.OTHERS, false, 21.45m);
            List<AbstractItem> items = new List<AbstractItem>();
            items.Add(item);
            items.Add(anotherItem);
            Type resultType = typeof(ImportedItem);
            Type anotherResule = typeof(TaxedItem);
            items = rule.Apply(items);
            Assert.IsNotNull(items);
            Assert.AreEqual(resultType, items[0].GetType());
            Assert.AreEqual(anotherResule, items[1].GetType());
        }
    }
}
