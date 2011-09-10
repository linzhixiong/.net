using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Items.Enums;
using SalesTaxes.Interface;

namespace SalesTaxes.Items
{
    /// <summary>
    /// Goods With no tax
    /// </summary>
    public class Item : AbstractItem
    {

        public Item(Category category, bool import, decimal original)
            : base(category, import, original)
        {

        }

        public override decimal Calculate()
        {
            return 0.00m;
        }
    }
}
