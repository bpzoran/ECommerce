using ECommerceModel;
using IECommerceBO.DiscountBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO.DiscountBO
{
    public class NoDiscountCreator : IDiscountCreator
    {
        public Discount GetDiscount(Order order)
        {
            return new NoDiscount();
        }
    }
}
