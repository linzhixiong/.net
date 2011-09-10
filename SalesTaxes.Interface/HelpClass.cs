using System;
using System.Collections.Generic;

namespace SalesTaxes.Interface
{
    public static class HelpClass
    {
        public static decimal Round(decimal mydecimal)
        {
            return Math.Ceiling(mydecimal * 20) / 20;
        }

        public static void GetTotalPrice(List<AbstractItem> itemList, ref decimal totalPrice, ref decimal SalesTaxes)
        {
            if (itemList != null && itemList.Count > 0)
            {
                foreach (var item in itemList)
                {
                    totalPrice += item.FinalPrice;
                    SalesTaxes += item.SaleTax;
                }
            }
        }
    }
}
