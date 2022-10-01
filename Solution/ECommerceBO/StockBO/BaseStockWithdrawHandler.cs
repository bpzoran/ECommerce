using ECommerceModel;
using ECommerceModel.Results;
using IECommerceBO;
using IECommerceBO.StockBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceBO.StockBO
{
    public abstract class BaseStockWithdrawHandler
    {
        protected Stock stock;
        public BaseStockWithdrawHandler(Stock stock)
        {
            this.stock = stock;
        }
    }
}
