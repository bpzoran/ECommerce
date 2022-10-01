using ECommerceModel;
using IECommerceBO.DiscountBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO.DiscountBO
{
    public class HappyHourDiscountCreator : IDiscountCreator
    {
        public HappyHourDiscountCreator() : base() { }

        public Discount GetDiscount(Order order)
        {
            var orderTime = order.OrderTime;
            if (orderTime.Hour >= 16 && orderTime.Hour <= 17)
            {
                return new PhoneNumberDiscount(order.ProceedingPhoneNumber);
            }
            return new NoDiscount();
        }
    }
}
