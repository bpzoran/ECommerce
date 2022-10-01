using ECommerceModel;
using IECommerceBO;
using IECommerceBO.StockBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceBO.StockBO
{
    public abstract class BaseStockAddHandler
    {
        protected Stock stock;
        protected IStockChecker stockChecker;
        public BaseStockAddHandler(Stock stock, IStockChecker stockChecker)
        {
            this.stock = stock;
            this.stockChecker = stockChecker;
        }

        protected void AddProductUpdateStock(Product product, float productQunatity)
        {
            ProductStock ps = stock.ProductStocks.Where(t => t.Product.ProductId == product.ProductId && t.Stock.StockId == stock.StockId).FirstOrDefault();
            ps.Quantity = stockChecker.GetQuantity(product);
            if (ps != null)
            {
                ps.Quantity += productQunatity;
            }
            else
            {
                ps = new ProductStock(product, stock, productQunatity);
                stock.ProductStocks.Add(ps);
            }
        }
    }
}
