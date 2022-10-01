using ECommerceBO.OrderBO.DiscountBO;
using ECommerceModel;
using ECommerceModel.Helpers;
using IECommerceBO;
using IECommerceBO.DiscountBO;
using IECommerceBO.OrderBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO
{
    public class HappyHourOrderCreator : BaseOrderCreator, IOrderCreator
    {
        public HappyHourOrderCreator(Customer customer, ProceedingData proceedingData) : base(customer, proceedingData) { }

        protected override IDiscountCreator GetDiscountCreator()
        {
            return new HappyHourDiscountCreator();
        }
    }
}
