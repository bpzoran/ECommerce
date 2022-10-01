using ECommerceModel;
using ECommerceModel.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace IECommerceBO.OrderBO
{
    public interface IListCartContentHandler
    {
        Result GetProductItems(string customerId);
    }
}
