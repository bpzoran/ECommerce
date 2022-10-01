using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.StockBO
{
    public interface IStockAddHandler
    {
        void AddProduct(Product product, float productQuantity);
    }
}
