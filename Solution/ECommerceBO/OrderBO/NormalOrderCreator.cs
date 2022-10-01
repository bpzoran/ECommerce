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
    public class NormalOrderCreator : BaseOrderCreator, IOrderCreator
    {
        public NormalOrderCreator(Customer customer, ProceedingData proceedingData) : base(customer, proceedingData)
        {
        }

        protected override IDiscountCreator GetDiscountCreator()
        {
            return new NoDiscountCreator();
        }
    }
}
