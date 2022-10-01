using ECommerceDAOAbstractFactory;
using ECommerceModel;
using ECommerceModel.Results;
using IECommerceBO.OrderBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO
{
    public class ListCartContentHandler : IListCartContentHandler
    {
        public ICustomerDAO CustomerDAO { private get; set; }

        public ListCartContentHandler()
        {
            CustomerDAO = DAOAbstractFactory.Instance.DAOFactory.CustomerDAO;
        }
        public Result GetProductItems(string customerId)
        {
            Result result = new Result();
            Customer customer = CustomerDAO.FindById(customerId);
            if (customer is null)
            {
                result.Log(LogLevel.Error, "Unknown customer");
            }
            List<ProductItem> productItems = customer.ShoppingCart;
            result.ResultObject = productItems;
            return result;
        }
    }
}
