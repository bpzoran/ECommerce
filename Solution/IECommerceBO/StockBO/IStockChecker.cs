using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.StockBO
{
    public interface IStockChecker
    {
        float GetQuantity(Product product);
    }
}
