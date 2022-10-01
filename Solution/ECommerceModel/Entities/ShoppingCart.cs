using ECommerceModel.ECommerceComparing;
using ECommerceModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceModel
{
    public class ShoppingCart : List<ProductItem>
    {
        public ShoppingCart() { }

        public new void Add(ProductItem item)
        {
            ProductItem updatingItem = this.Where(t => t.Product.ProductId == item.Product.ProductId).FirstOrDefault();
            if (!(updatingItem == null))
            {
                updatingItem.Quantity += item.Quantity;
                return;
            }
            base.Add(item);
        }



    }
}
