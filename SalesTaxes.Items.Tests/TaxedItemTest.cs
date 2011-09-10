using NUnit.Framework;
using SalesTaxes.Interface;

namespace SalesTaxes.Items.Tests
{
    [TestFixture]
    public class TaxedItemTest
    {
        [Test]
        public void SaletaxTest()
        {
            AbstractItem item = new Item(Enums.Category.BOOK, true, 18.99m);
            item = new TaxedItem(item);

            decimal result = 1.90m;
            Assert.AreEqual(result, item.SaleTax);

            AbstractItem anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            anotherItem = new TaxedItem(anotherItem);
            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.SaleTax);
        }

        [Test]
        public void FinalPriceTest()
        {
            AbstractItem item = new Item(Enums.Category.BOOK, true, 18.99m);
            item = new TaxedItem(item);
            decimal result = 20.89m;
            Assert.AreEqual(result, item.FinalPrice);

            AbstractItem anotherItem = new Item(Enums.Category.BOOK, true, 0m);
            anotherItem = new TaxedItem(anotherItem);
            decimal anotherResult = 0.00m;
            Assert.AreEqual(anotherResult, anotherItem.FinalPrice);
        }
    }
}
