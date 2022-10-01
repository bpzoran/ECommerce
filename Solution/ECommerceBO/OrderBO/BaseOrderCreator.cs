using ECommerceBO.OrderBO.DiscountBO;
using ECommerceBO.TimeAssignBO;
using ECommerceModel;
using ECommerceModel.Helpers;
using IECommerceBO;
using IECommerceBO.DiscountBO;
using IECommerceBO.OrderBO;
using IECommerceBO.TimeAssignBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceBO.OrderBO
{
    public abstract class BaseOrderCreator : IOrderCreator
    {
        protected Customer customer;
        protected ProceedingData proceedingData;
        protected abstract IDiscountCreator GetDiscountCreator();

        public ITimeAssigner TimeAssigner { get; set; }

        public BaseOrderCreator(Customer customer, ProceedingData proceedingData)
        {
            this.TimeAssigner = new NormalTimeAssigner();
            this.customer = customer;
            this.proceedingData = proceedingData;
            ApplyProceedingData();
        }

        private void ApplyProceedingData()
        {
            if (string.IsNullOrEmpty(proceedingData.ProceedingCity))
            {
                proceedingData.ProceedingCity = customer.City;
            }
            if (string.IsNullOrEmpty(proceedingData.ProceedingHouseNumber))
            {
                proceedingData.ProceedingHouseNumber = customer.HouseNumber;
            }
            if (string.IsNullOrEmpty(proceedingData.ProceedingPhoneNumber))
            {
                proceedingData.ProceedingPhoneNumber = customer.PhoneNumber;
            }
            if (string.IsNullOrEmpty(proceedingData.ProceedingStreet))
            {
                proceedingData.ProceedingStreet = customer.Street;
            }
        }

        public Order ApplyShoppingCart()
        {
            Order order = new Order
            {
                OrderTime = TimeAssigner.DateTime
            };
            ApplyProductItems(order);
            ApplyOrderHeader(order);
            return order;
        }

        private void ApplyOrderHeader(Order order)
        {
            order.Customer = customer;
            ApplyDelivery(order);
            order.InitialTotalPrice = this.customer.ShoppingCart.Sum(t => t.UnitPrice * t.Quantity);            
            order.FinalTotalPrice = GetFinalTotalPrice(order);
        }

        private void ApplyProductItems(Order order)
        {
            order.Items.AddRange(this.customer.ShoppingCart);
        }

        private void ApplyDelivery(Order order)
        {
            order.ProceedingCity = this.proceedingData.ProceedingCity;
            order.ProceedingHouseNumber = this.proceedingData.ProceedingHouseNumber;
            order.ProceedingPhoneNumber = this.proceedingData.ProceedingPhoneNumber;
            order.ProceedingStreet = this.proceedingData.ProceedingStreet;
        }

        private float GetFinalTotalPrice(Order order)
        {
            float discountPercentage = this.GetDiscountCreator().GetDiscount(order).GetDiscountPercentage();
            if (discountPercentage == 0f)
            {
                return order.InitialTotalPrice;
            }
            return (1f - discountPercentage / 100f) * order.InitialTotalPrice;
        }
    }
}
