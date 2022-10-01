using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel
{
    public class ProductStock
    {
        public ProductStock(Product product, Stock stock, float quantity)
        {
            this.Product = product;
            this.Stock = stock;
            this.Quantity = quantity;
        }

        public Product Product { get; set; }
        public Stock Stock { get; set; }
        public float Quantity { get; set; }
    }
}
