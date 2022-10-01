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
    public class CommonStockWithdrawHandler: IStockWithdrawHandler
    {
        public IStockWithdrawHandler LocalStockWithdrawHandler { private get; set; }
        public IStockWithdrawHandler SupplierStockWithdrawHandler { private get; set; }
        public IStockAddHandler LocalStockAddHandler { private get; set; }
        public IStockAddHandler SupplierStockAddHandler { private get; set; }

        public CommonStockWithdrawHandler(LocalStock localStock, SupplierStock supplierStock, ISupplierStockService supplierStockService)
        {
            LocalStockWithdrawHandler = new LocalStockWithdrawHandler(localStock);
            SupplierStockWithdrawHandler = new SupplierStockWithdrawHandler(supplierStock, supplierStockService);
            LocalStockAddHandler = new LocalStockAddHandler(localStock);
            SupplierStockAddHandler = new SupplierStockAddHandler(supplierStock, supplierStockService);
        }

        public void WithdrawProduct(Product product, float quantity, out float missingQuantity, Result result)
        {
            missingQuantity = 0;
            LocalStockWithdrawHandler.WithdrawProduct(product, quantity, out float localStockMissingQuantity, result);
            if (!result.Success)
            {
                SupplierStockWithdrawHandler.WithdrawProduct(product, localStockMissingQuantity, out missingQuantity, result);
                if (result.Success)
                {
                    SupplierStockAddHandler.AddProduct(product, localStockMissingQuantity - missingQuantity);
                    LocalStockAddHandler.AddProduct(product, quantity - localStockMissingQuantity);
                }
            }
        }

    }
}
