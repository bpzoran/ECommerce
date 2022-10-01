using ECommerceModel;
using IECommerceBO;
using IECommerceBO.StockBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceBO.StockBO
{
    public class LocalStockChecker : IStockChecker
    {
        public Stock stock;
        public LocalStockChecker(Stock stock)
        {
            this.stock = stock;
        }
        public float GetQuantity(Product product)
        {
            return stock.ProductStocks.FirstOrDefault(t => t.Product.ProductId == product.ProductId).Quantity;
        }
    }
}
