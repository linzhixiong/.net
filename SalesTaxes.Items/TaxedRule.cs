using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Interface;
using SalesTaxes.Items.Enums;
namespace SalesTaxes.Items
{
    public class TaxedRule : ITaxedRule
    {
        public List<AbstractItem> Apply(List<AbstractItem> items)
        {
            List<AbstractItem> itemlist = new List<AbstractItem>();
            foreach (var item in items)
            {
                AbstractItem newItem = Apply(item);

                itemlist.Add(newItem);
            }
            return itemlist;
        }

        public AbstractItem Apply(AbstractItem item)
        {
            switch (item.Category)
            {
                case Category.BOOK:
                    break;
                case Category.FOOD:
                    break;
                case Category.MEDICAL:
                    break;
                default:
                    item = new TaxedItem(item);
                    break;
            }

             item = item.IsImport? item = new ImportedItem(item) :item;
            
            return item;
        }
    }
}
