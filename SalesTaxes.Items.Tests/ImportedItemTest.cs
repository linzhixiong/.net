using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SalesTaxes.Interface;

namespace SalesTaxes.Items.Tests
{
    [TestFixture ]
   public  class ImportedItemTest
    {
        [Test]
        public void SaletaxTest()
        {
            AbstractItem item = new Item(Enums.Category.BOOK, true, 11.25m);
            item = new ImportedItem(item);

            decimal result = 0.60m;
            Assert.AreEqual(result, item.SaleTax);

            AbstractItem anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            anotherItem = new ImportedItem(anotherItem);
            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.SaleTax);
        }

        [Test]
        public void FinalPriceTest()
        {
            AbstractItem item = new Item(Enums.Category.BOOK, true, 11.25m);
            item = new ImportedItem(item);
            decimal result = 11.85m;
            Assert.AreEqual(result, item.FinalPrice);

            AbstractItem anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            anotherItem = new ImportedItem(anotherItem);
            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.FinalPrice);
        }

        [Test]
        public void MultipleSaletaxTest()
        {
            AbstractItem item = new Item(Enums.Category.BOOK, true, 47.50m);
            item = new ImportedItem(item);
            item = new TaxedItem(item);
           
            decimal result = 7.15m;
            Assert.AreEqual(result, item.SaleTax);

            AbstractItem nexeItem = new Item(Enums.Category.BOOK, true, 47.50m);
            nexeItem = new TaxedItem(nexeItem);
            nexeItem = new ImportedItem(nexeItem);

            decimal nextResult = 7.15m;
            Assert.AreEqual(nextResult, nexeItem.SaleTax);

            AbstractItem anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            anotherItem = new TaxedItem(anotherItem);
            anotherItem = new ImportedItem(anotherItem);

            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.SaleTax);
        }

        [Test]
        public void MutipleTaxesFinalPriceTest()
        {
            AbstractItem item = new Item(Enums.Category.BOOK, true, 47.50m);
            item = new ImportedItem(item);
            item = new TaxedItem(item);
            decimal result = 54.65m;
            Assert.AreEqual(result, item.FinalPrice);

            AbstractItem anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            anotherItem = new ImportedItem(anotherItem);
            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.FinalPrice);
        }
    }
}
