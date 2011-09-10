using System.Collections.Generic;

namespace SalesTaxes.Interface
{
    public interface ITaxedRule
    {
        List<AbstractItem> Apply(List<AbstractItem> items);

        AbstractItem Apply(AbstractItem item);
    }
}
