using ECommerceModel;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceDAOInMemory
{
    public class SupplierStockRepo : BaseRepo<SupplierStock>, ISupplierStockDAO
    {

        public SupplierStock GetDefaultSupplierStock(Supplier supplier)
        {
            return ECommerceDatabase.Instance.SupplierStocks.FirstOrDefault(t => t.Value.Supplier.SupplierId == supplier.SupplierId && t.Value.IsDefault).Value;
        }
    }
}
