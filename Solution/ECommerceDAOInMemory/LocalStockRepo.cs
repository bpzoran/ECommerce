using ECommerceModel;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceDAOInMemory
{
    public class LocalStockRepo: BaseRepo<LocalStock>, ILocalStockDAO
    {
        public LocalStock GetDefaultLocalStock()
        {
            return ECommerceDatabase.Instance.LocalStocks.FirstOrDefault(t => t.Value.IsDefault).Value;
        }
    }
}
