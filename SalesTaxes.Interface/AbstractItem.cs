using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SalesTaxes.Items.Enums;

namespace SalesTaxes.Interface
{
    public abstract class AbstractItem
    {
        private decimal originalPrice;
        private bool isImport;
        private Category category;
        public AbstractItem(Category category, bool isImport, decimal originalPrice)
        {
            this.originalPrice = originalPrice;
            this.category = category;
            this.isImport = isImport;
        }

        public virtual decimal FinalPrice
        {
            get
            {
                return System.Math.Round(this.originalPrice + this.SaleTax, 2);
            }
        }

        public decimal SaleTax
        {
            get
            {
                return Math.Ceiling(this.Calculate() * 20) / 20;
            }
        }

        public decimal OriginalPrice
        {
            get
            {
                return this.originalPrice;
            }
        }

        public Category Category
        {
            get { return category; }

        }

        public bool IsImport
        {
            get { return isImport; }
        }

        public abstract decimal Calculate();
    }
}
