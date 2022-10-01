using ECommerceBO.StockBO;
using ECommerceModel;
using ECommerceModel.Results;
using IECommerceBO.OrderBO;
using IECommerceBO.StockBO;
using IECommerceBO.SupplierBO;
using IECommerceDAO;
using SupplierWebService;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO
{
    public class CommonAddToShoppingCartHandler : BaseAddToShoppingCartHandler, IAddToShoppingCartHandler
    {      
        public CommonAddToShoppingCartHandler(string customerId) : base(customerId) {
            SupplierStockService = new SupplierStockService();
        }

        public Result AddToShoppingCart(string productId, float quantity)
        {
            Result result = new Result();
            if (customer is null)
            {
                result.Log(LogLevel.Error, $"Unknown customer");
                return result;
            }
            Product product = ProductDAO.FindById(productId);
            Supplier supplier = product.Supplier;
            SupplierStock supplierStock = SupplierStockDAO.GetDefaultSupplierStock(supplier);
            var commonStockChecker = new CommonStockChecker(localStock, supplierStock, SupplierStockService);
            if (commonStockChecker.CheckAvailability(product, quantity, result))
            {
                IStockWithdrawHandler commonStockWithdrawHandler = new CommonStockWithdrawHandler(localStock, supplierStock, SupplierStockService);
                commonStockWithdrawHandler.WithdrawProduct(product, quantity, out float missingQuantity, result);
                if (missingQuantity > 0)
                {
                    result.Log(LogLevel.Error, $"Missing quantity for the product: {missingQuantity}");
                }
                if (result.Success)
                {
                    customer.ShoppingCart.Add(new ProductItem(product, quantity));
                    CustomerDAO.Update(customer);                    
                }
            }
            result.ResultObject = customer.ShoppingCart;
            return result;
        }
    }
}
