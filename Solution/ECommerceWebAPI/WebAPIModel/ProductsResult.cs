using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.WebAPIModel
{
    public class ProductsResult: BaseWebAPIResult
    {
        public List<ProductResult> Products { get; set; }
        
        public ProductsResult(List<Product> products)
        {
            products.ForEach(t => Products.Add(new ProductResult(t)));
        }

        protected override void InitProps()
        {
            Products = new List<ProductResult>();
        }
    }
}
