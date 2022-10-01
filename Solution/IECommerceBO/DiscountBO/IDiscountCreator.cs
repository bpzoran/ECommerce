using ECommerceModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.DiscountBO
{
    public interface IDiscountCreator
    {
        Discount GetDiscount(Order order);
    }
}
