using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SalesTaxes.Items.Enums;
using SalesTaxes.Interface;

namespace SalesTaxes.Items.Tests
{
    [TestFixture]
    public class HelpClassTest
    {
        [Test]
        public void RoundTest()
        {
            decimal dbTest1 = 0.5523m;
            decimal dbResult1 = 0.60m;
            Assert.AreEqual(dbResult1, HelpClass.Round(dbTest1));

            decimal dbTest2 = 1.06m;
            decimal dbResult2 = 1.1m;
            Assert.AreEqual(dbResult2, HelpClass.Round(dbTest2));

            decimal dbTest3 = 2.164m;
            decimal dbResult3 = 2.2m;
            Assert.AreEqual(dbResult3, HelpClass.Round(dbTest3));

            decimal dbTest4 = 2.144m;
            decimal dbResult4 = 2.15m;
            Assert.AreEqual(dbResult4, HelpClass.Round(dbTest4));
            decimal dbTest5= 2.151m;
            decimal dbResult5 = 2.2m;
            Assert.AreEqual(dbResult5, HelpClass.Round(dbTest5));
        }

        [Test]
        public void GetTotalPriceTest_GroupOne()
        {
            List<AbstractItem> items = new List<AbstractItem>();
            items.Add(new Item(Category.BOOK, false, 12.49m));
            items.Add(new Item(Category.OTHERS, false, 14.99m));
            items.Add(new Item(Category.FOOD, false, 0.85m));

            List<AbstractItem> itemList = new TaxedRule().Apply(items);
            decimal totalPrice = 0.0m;
            decimal salesTaxes = 0.0m;
            decimal totalPriceResult = 29.83m;
            decimal salesTaxesResult = 1.50m;
            HelpClass.GetTotalPrice(itemList, ref totalPrice, ref salesTaxes);
            Assert.AreEqual(totalPriceResult, totalPrice);
            Assert.AreEqual(salesTaxesResult, salesTaxesResult);
        }

        [Test]
        public void GetTotalPriceTest_GroupTwo()
        {
            List<AbstractItem> items = new List<AbstractItem>();
            items.Add(new Item(Category.FOOD, true, 10.00m));
            items.Add(new Item(Category.OTHERS, true, 47.50m));

            List<AbstractItem> itemList = new TaxedRule().Apply(items);
            decimal totalPrice = 0.0m;
            decimal salesTaxes = 0.0m;
            decimal totalPriceResult = 65.15m;
            decimal salesTaxesResult = 7.65m;
            HelpClass.GetTotalPrice(itemList, ref totalPrice, ref salesTaxes);
            Assert.AreEqual(totalPriceResult, totalPrice);
            Assert.AreEqual(salesTaxesResult, salesTaxesResult);
        }

        [Test]
        public void GetTotalPriceTest_GrouThree()
        {
            List<AbstractItem> items = new List<AbstractItem>();
            items.Add(new Item(Category.OTHERS, true, 27.99m));
            items.Add(new Item(Category.OTHERS, false, 18.99m));
            items.Add(new Item(Category.MEDICAL, false, 9.75m));
            items.Add(new Item(Category.FOOD, true, 11.25m));

            List<AbstractItem> itemList = new TaxedRule().Apply(items);
            decimal totalPrice = 0.0m;
            decimal salesTaxes = 0.0m;
            decimal totalPriceResult = 74.68m;
            decimal salesTaxesResult = 6.70m;
            HelpClass.GetTotalPrice(itemList, ref totalPrice, ref salesTaxes);
            Assert.AreEqual(totalPriceResult, totalPrice);
            Assert.AreEqual(salesTaxesResult, salesTaxesResult);
        }
    }
}
