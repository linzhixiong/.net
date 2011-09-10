using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace SalesTaxes.Items.Tests
{
    [TestFixture]
    public class ItemTest
    {
        [Test]
        public void SaletaxTest()
        {
            Item item = new Item(Enums.Category.BOOK, true, 12.49m);
            decimal result = 0.00m;
            Assert.AreEqual(result, item.SaleTax);

            Item anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.SaleTax);
        }

        [Test]
        public void FinalPriceTest()
        {
            Item item = new Item(Enums.Category.BOOK, true, 12.49m);
            decimal result = 12.49m;
            Assert.AreEqual(result, item.FinalPrice);

            Item anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.FinalPrice);
        }
    }
}
