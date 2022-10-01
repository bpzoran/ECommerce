using IECommerceBO.DiscountBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO.DiscountBO
{
    public class NoDiscount : Discount
    {
        public override float GetDiscountPercentage()
        {
            return 0;
        }
    }
}
