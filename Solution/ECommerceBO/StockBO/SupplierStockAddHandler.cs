using ECommerceModel;
using IECommerceBO;
using IECommerceBO.StockBO;
using IECommerceBO.SupplierBO;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceBO.StockBO
{
    public class SupplierStockAddHandler : BaseStockAddHandler, IStockAddHandler
    {
        private readonly ISupplierStockService supplierStockService;
        public SupplierStockAddHandler(SupplierStock stock, ISupplierStockService supplierStockService) : base(stock, new SupplierStockChecker(stock, supplierStockService))
        {
            this.supplierStockService = supplierStockService;
        }

        public void AddProduct(Product product, float productQuantity)
        {
            AddProductUpdateStock(product, productQuantity);
            supplierStockService.UpdateProduct(((SupplierStock)stock).WebServiceURL, product.ProductId, stock.ProductStocks.Where(t => t.Product.ProductId == product.ProductId).FirstOrDefault().Quantity);
        }
    }
}
