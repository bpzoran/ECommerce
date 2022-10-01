using ECommerceBO.TimeAssignBO;
using ECommerceDAOAbstractFactory;
using ECommerceModel;
using ECommerceModel.Helpers;
using ECommerceModel.Results;
using IECommerceBO.OrderBO;
using IECommerceBO.TimeAssignBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO
{
    public class CheckoutHandler : ICheckoutHandler
    {
        public ICustomerDAO CustomerDAO { private get; set; }
        public IOrderDAO OrderDAO { private get; set; }
        public IOrderCreator OrderCreator { private get; set; }
        public ITimeAssigner TimeAssigner { private get; set; }
        public ProceedingData ProceedingData { private get; set; }
        private readonly Customer customer;

        public CheckoutHandler(string customerId, ProceedingData proceedingData)
        {
            Init();
            customer = CustomerDAO.FindById(customerId);
            this.ProceedingData = proceedingData;
            InitOrderCreator(customer);
        }

        public CheckoutHandler(Customer customer, ProceedingData proceedingData)
        {
            Init();
            this.customer = customer;
            this.ProceedingData = proceedingData;
            InitOrderCreator(customer);
        }

        public CheckoutHandler(IOrderCreator orderCreator)
        {
            this.OrderCreator = orderCreator;
        }


        public Result Checkout()
        {
            Result result = new Result();
            OrderCreator.TimeAssigner = TimeAssigner;
            if (OrderCreator == null)
            {
                result.Log(LogLevel.Error, $"Unknown customer or invalid input parameters");
                return result;
            }
            Order order = OrderCreator.ApplyShoppingCart();
            if (!OrderDAO.Insert(order))
            {
                result.Log(LogLevel.Error, $"Unsuccesful storing to db");
            } else
            {
                customer.ShoppingCart.Clear();
                CustomerDAO.Update(customer);
            }

            result.ResultObject = order;
            return result;
        }

        private void Init()
        {
            CustomerDAO = DAOAbstractFactory.Instance.DAOFactory.CustomerDAO;
            OrderDAO = DAOAbstractFactory.Instance.DAOFactory.OrderDAO;
            this.TimeAssigner = new NormalTimeAssigner();
        }

        private void InitOrderCreator(Customer customer)
        {
            if (customer != null)
            {
                OrderCreator = new HappyHourOrderCreator(customer, ProceedingData);
            }
        }
    }
}
