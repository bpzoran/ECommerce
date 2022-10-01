using ECommerceModel;
using IECommerceBO;
using IECommerceBO.StockBO;
using IECommerceBO.SupplierBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.StockBO
{
    public class SupplierStockChecker : IStockChecker
    {
        private readonly SupplierStock supplierStock;
        private readonly ISupplierStockService service;
        public SupplierStockChecker(SupplierStock supplierStock, ISupplierStockService service) {
            this.supplierStock = supplierStock;
            this.service = service;
        }
        public float GetQuantity(Product product)
        {
            return service.GetQuantity(supplierStock.WebServiceURL, product.ProductId);
        }
    }
}
