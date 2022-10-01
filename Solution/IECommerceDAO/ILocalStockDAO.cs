using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceDAO
{
    public interface ILocalStockDAO: IRepository<LocalStock>
    {
        LocalStock GetDefaultLocalStock();
    }
}
