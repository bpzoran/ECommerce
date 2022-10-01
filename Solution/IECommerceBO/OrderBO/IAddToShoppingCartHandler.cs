using ECommerceModel.Results;
using IECommerceBO.SupplierBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.OrderBO
{
    public interface IAddToShoppingCartHandler
    {
        Result AddToShoppingCart(string productId, float quantity);
    }
}
