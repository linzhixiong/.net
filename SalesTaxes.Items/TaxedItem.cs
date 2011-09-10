using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Interface;

namespace SalesTaxes.Items
{
    /// <summary>
    ///Common Goods with 10% tax
    /// </summary>
    public class TaxedItem : AbstractItem
    {
        AbstractItem decoratorItem;
        public TaxedItem(AbstractItem item)
            : base(item.Category, item.IsImport, item.OriginalPrice)
        {
            this.decoratorItem = item;
        }

        public override decimal Calculate()
        {
            return decoratorItem.Calculate() + OriginalPrice * 10 / 100;
        }
    }
}
