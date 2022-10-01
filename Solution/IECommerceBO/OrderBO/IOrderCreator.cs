using ECommerceModel;
using IECommerceBO.TimeAssignBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.OrderBO
{
    public interface IOrderCreator
    {
        Order ApplyShoppingCart();
        ITimeAssigner TimeAssigner { get; set; }
    }
}
