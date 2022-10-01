using ECommerceModel.Helpers;
using ECommerceModel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.OrderBO
{
    public interface ICheckoutHandler
    {
        Result Checkout();
    }
}
