using ECommerceDAOAbstractFactory;
using ECommerceModel;
using IECommerceBO;
using IECommerceBO.StockBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.StockBO
{
    public class LocalStockAddHandler : BaseStockAddHandler, IStockAddHandler
    {
        public ILocalStockDAO StockDAO { private get; set; }
        public IProductDAO ProductDAO { private get; set; }

        public LocalStockAddHandler(LocalStock stock) : base(stock, new LocalStockChecker(stock))
        {
            StockDAO = DAOAbstractFactory.Instance.DAOFactory.LocalStockDAO;
            ProductDAO = DAOAbstractFactory.Instance.DAOFactory.ProductDAO;
            this.stock = stock;
        }

        public void AddProduct(Product product, float productQuantity)
        {
            ProductDAO.InsertIfDoesNotExist(product);
            AddProductUpdateStock(product, productQuantity);
            StockDAO.Update((LocalStock)stock);
        }
    }
}
