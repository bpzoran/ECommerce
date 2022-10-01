using ECommerceDAOAbstractFactory;
using ECommerceModel;
using IECommerceBO.ProductBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.ProductBO
{
    public class ProductListingHandler : IProductListingHandler
    {
        public IProductDAO ProductDAO { private get; set; }
        
        public ProductListingHandler()
        {
            ProductDAO = DAOAbstractFactory.Instance.DAOFactory.ProductDAO;
        }
        public List<Product> GetAllProducts()
        {
            return ProductDAO.GetList();
        }
    }
}
