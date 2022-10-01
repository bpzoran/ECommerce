using ECommerceDAOAbstractFactory;
using ECommerceModel;
using ECommerceModel.Results;
using IECommerceBO;
using IECommerceBO.StockBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceBO.StockBO
{
    public class LocalStockWithdrawHandler : BaseStockWithdrawHandler, IStockWithdrawHandler
    {
        public ILocalStockDAO StockDAO { private get; set; }
        public IProductDAO ProductDAO { private get; set; }


        public LocalStockWithdrawHandler(LocalStock stock) : base(stock)
        {
            this.stock = stock;
            StockDAO = DAOAbstractFactory.Instance.DAOFactory.LocalStockDAO;
            ProductDAO = DAOAbstractFactory.Instance.DAOFactory.ProductDAO;
        }



        public void WithdrawProduct(Product product, float quantity, out float missingQuantity, Result result)
        {
            ProductDAO.InsertIfDoesNotExist(product);
            WithdrawProductUpdateStock(product, quantity, out missingQuantity);
            if (result.Success)
            {
                if (!StockDAO.Update((LocalStock)stock))
                {
                    result.Log(LogLevel.Error, "Unsuccesful stock update");
                }
            }
        }

        protected bool WithdrawProductUpdateStock(Product product, float quantity, out float missingQuantity)
        {
            ProductStock ps = stock.ProductStocks.Where(t => t.Product.ProductId == product.ProductId && t.Stock.StockId == stock.StockId).FirstOrDefault();
            if (ps != null)
            {
                return UpdateExistingProductOnStock(ps, quantity, out missingQuantity);
            }
            else
            {
                return AddMissingProductOnStock(product, quantity, out missingQuantity);
            }
        }

        private bool UpdateExistingProductOnStock(ProductStock ps, float quantity, out float missingQuantity)
        {
            missingQuantity = quantity - ps.Quantity;
            if (missingQuantity > 0)
            {
                ps.Quantity = 0;
                return false;
            }
            else
            {
                missingQuantity = 0;
                ps.Quantity -= quantity;
                return true;
            }
        }

        private bool AddMissingProductOnStock(Product product, float quantity, out float missingQuantity)
        {
            ProductStock ps = new ProductStock(product, stock, 0);
            stock.ProductStocks.Add(ps);
            missingQuantity = quantity;
            return false;
        }
    }
}
