using ECommerceModel;
using ECommerceModel.Results;
using IECommerceBO;
using IECommerceBO.StockBO;
using IECommerceBO.SupplierBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.StockBO
{
    public class CommonStockChecker
    {
        public IStockChecker LocalStockChecker { private get; set; }
        public IStockChecker SupplierStockChecker { private get; set; }

        public CommonStockChecker(LocalStock localStock, SupplierStock supplierStock, ISupplierStockService supplierStockService)
        {
            LocalStockChecker = new LocalStockChecker(localStock);
            SupplierStockChecker = new SupplierStockChecker(supplierStock, supplierStockService);
        }

        public bool CheckAvailability(Product product, float quantity, Result result)
        {
            float missingQuantity1 = quantity - LocalStockChecker.GetQuantity(product);
            if (missingQuantity1 > 0)
            {
                float misslingQuantity2 = missingQuantity1 - SupplierStockChecker.GetQuantity(product);
                if (misslingQuantity2 > 0)
                {
                    result.Log(LogLevel.Error, "Missing quantity: " + misslingQuantity2);
                    return false;
                }
            }
            return true;
        }
    }
}
