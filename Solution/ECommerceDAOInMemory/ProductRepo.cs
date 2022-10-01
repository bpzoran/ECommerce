using ECommerceModel;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDAOInMemory
{
    public class ProductRepo: BaseRepo<Product>, IProductDAO
    {
    }
}
