using ECommerceDAOAbstractFactory;
using ECommerceModel;
using IECommerceBO.SupplierBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO
{
    public abstract class BaseAddToShoppingCartHandler
    {
        protected Customer customer;

        protected LocalStock localStock;
        public ICustomerDAO CustomerDAO { protected get; set; }
        public IProductDAO ProductDAO { protected get; set; }
        public ILocalStockDAO LocalStockDAO { protected get; set; }
        public ISupplierStockDAO SupplierStockDAO { protected get; set; }

        public ISupplierStockService SupplierStockService { protected get; set; }
        public BaseAddToShoppingCartHandler(string customerId)
        {
            CustomerDAO = DAOAbstractFactory.Instance.DAOFactory.CustomerDAO;
            ProductDAO = DAOAbstractFactory.Instance.DAOFactory.ProductDAO;
            LocalStockDAO = DAOAbstractFactory.Instance.DAOFactory.LocalStockDAO;
            SupplierStockDAO = DAOAbstractFactory.Instance.DAOFactory.SupplierStockDAO;
            localStock = LocalStockDAO.GetDefaultLocalStock();
            customer = CustomerDAO.FindById(customerId);
        }
    }
}
