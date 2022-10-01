using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceWebAPI.WebAPIModel
{
    public class ProductItemResult: BaseWebAPIResult
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float UnitPrice { get; set; }

        public ProductItemResult(ProductItem productItem)
        {
            this.ProductId = productItem.Product.ProductId;
            this.ProductName = productItem.Product.ProductName;
            this.Quantity = productItem.Quantity;
            this.UnitPrice = productItem.UnitPrice;
        }

        protected override void InitProps()
        {
            this.ProductId = string.Empty;
            this.ProductName = string.Empty;
            this.Quantity = 0f;
            this.UnitPrice = 0f;
        }
    }
}
