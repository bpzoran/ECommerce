using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceDAO
{
    public interface ISupplierStockDAO : IRepository<SupplierStock>
    {
        SupplierStock GetDefaultSupplierStock(Supplier supplier);
    }
}
