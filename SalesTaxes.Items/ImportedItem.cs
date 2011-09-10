using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Interface;

namespace SalesTaxes.Items
{
    /// <summary>
    /// Imported goods with extra 5% tax
    /// </summary>
    public class ImportedItem : AbstractItem
    {
        AbstractItem decoratorItem;
        public ImportedItem(AbstractItem item)
            : base(item.Category, item.IsImport, item.OriginalPrice)
        {
            decoratorItem = item;
        }

        public override decimal Calculate()
        {
            return decoratorItem.Calculate() + OriginalPrice * 5 / 100;
        }
    }
}
