using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel
{
    public class ProductItem
    {
        public ProductItem(Product product, float quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = product.ProductPrice;
        }


        public Product Product { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }
    }
}
