using System;
using System.Collections.Generic;
using SalesTaxes.Items;
using SalesTaxes.Interface;
using SalesTaxes.Items.Enums;
using System.Configuration;
using System.Reflection;

namespace SalesTaxes.Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            string ruleTypeName = ConfigurationSettings.AppSettings["RuleType"];
            Assembly assem = Assembly.Load("SalesTaxes.Items");
            ITaxedRule taxedRule = assem.CreateInstance(ruleTypeName) as ITaxedRule;
          
            List<AbstractItem> items = new List<AbstractItem>();
            items.Add(new Item(Category.BOOK, false, 12.49m));
            items.Add(new Item(Category.OTHERS, false, 14.99m));
            items.Add(new Item(Category.FOOD, false, 0.85m));

            PrintPrice(taxedRule.Apply(items));
            Console.WriteLine("--------------");

            items.Clear();
            items.Add(new Item(Category.FOOD, true, 10.00m));
            items.Add(new Item(Category.OTHERS, true, 47.50m));
            PrintPrice(taxedRule.Apply(items));
            Console.WriteLine("--------------");

            items.Clear();
            items.Add(new Item(Category.OTHERS, true, 27.99m));
            items.Add(new Item(Category.OTHERS, false, 18.99m));
            items.Add(new Item(Category.MEDICAL, false, 9.75m));
            items.Add(new Item(Category.FOOD, true, 11.25m));
            PrintPrice(taxedRule.Apply(items));
            Console.Read();
        }

        private static void PrintPrice(List<AbstractItem> itemlist)
        {
            foreach (var item in itemlist)
            {
                Console.WriteLine("{0},{1},{2}", item.Category, item.IsImport, item.FinalPrice);
            }

            decimal totalPrice = 0.00m;
            decimal salesTaxes = 0.00m;
            HelpClass.GetTotalPrice(itemlist, ref totalPrice, ref salesTaxes);
            Console.Write("---");
            Console.WriteLine("SaleTaxes:{0}", salesTaxes);
            Console.Write("---");
            Console.WriteLine("Total:{0}", totalPrice);
        }
    }
}
