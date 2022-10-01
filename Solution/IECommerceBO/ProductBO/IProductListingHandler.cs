using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.ProductBO
{
    public interface IProductListingHandler
    {
        List<Product> GetAllProducts();
    }
}
