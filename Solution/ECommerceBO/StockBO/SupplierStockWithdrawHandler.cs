using ECommerceModel;
using ECommerceModel.Results;
using IECommerceBO;
using IECommerceBO.StockBO;
using IECommerceBO.SupplierBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceBO.StockBO
{
    public class SupplierStockWithdrawHandler : BaseStockWithdrawHandler, IStockWithdrawHandler
    {
        private readonly ISupplierStockService supplierStockService;
        public SupplierStockWithdrawHandler(SupplierStock stock, ISupplierStockService supplierStockService) : base(stock)
        {
            this.supplierStockService = supplierStockService;
        }

        public void WithdrawProduct(Product product, float quantity, out float missingQuantity, Result result)
        {
            float quantityOnStock = supplierStockService.GetQuantity(((SupplierStock)stock).WebServiceURL, product.ProductId);
            missingQuantity = quantity - quantityOnStock;
            if (missingQuantity > 0)
            {
                result.Log(LogLevel.Error, "Missing products on supplier stock");
            }
            else if (!supplierStockService.WithdrawProduct(((SupplierStock)stock).WebServiceURL, product.ProductId, quantityOnStock))
            {
                result.Log(LogLevel.Error, "Missing products on supplier stock");
            }
        }

    }
}
