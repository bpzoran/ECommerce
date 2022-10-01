using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceBO.OrderBO;
using ECommerceBO.TimeAssignBO;
using ECommerceModel;
using ECommerceModel.Helpers;
using ECommerceModel.Results;
using ECommerceWebAPI.WebAPIModel;
using IECommerceBO.OrderBO;
using IECommerceBO.TimeAssignBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutOrderController : ControllerBase
    {
        public CheckoutOrderController() : base()
        {
            this.TimeAssigner = new NormalTimeAssigner();
        }

        public ITimeAssigner TimeAssigner { private get; set; }

        [HttpGet("{customerId}", Name = "GetCheckoutOrder")]
        public OrderResult Get(string customerId)
        {
            return new OrderResult(GetOrder(customerId, new ProceedingData()));
        }

        [HttpGet("{customerId}/{city}/{street}/{houseNumber}/{phoneNumber}", Name = "GetCheckoutOrderWithDeliveryData")]
        public OrderResult Get(string customerId, string city, string street, string houseNumber, string phoneNumber)
        {            
            ProceedingData proceedingData = new ProceedingData(city, street, houseNumber, phoneNumber);
            Order order = GetOrder(customerId, proceedingData);
            order.Apply(proceedingData);
            return new OrderResult(order);
        }

        private Order GetOrder(string customerId, ProceedingData proceedingData)
        {
            ICheckoutHandler checkoutHandler = new CheckoutHandler(customerId, proceedingData) { TimeAssigner = TimeAssigner };
            Result result = checkoutHandler.Checkout();
            if ((result == null || result.ResultObject == null || !(result.ResultObject is Order)))
            {
                return new Order();
            }
            return (Order)result.ResultObject;
        }
    }
}
