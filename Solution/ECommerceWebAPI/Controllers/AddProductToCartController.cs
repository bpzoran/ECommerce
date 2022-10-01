using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceBO.OrderBO;
using ECommerceModel;
using ECommerceModel.Results;
using ECommerceWebAPI.Constants;
using ECommerceWebAPI.WebAPIModel;
using IECommerceBO.OrderBO;
using IECommerceBO.SupplierBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplierWebService;

namespace ECommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddProductToCartController : ControllerBase
    {
        public ISupplierStockService SupplierStockService { private get; set; }

        public AddProductToCartController() : base()
        {
            this.SupplierStockService = new SupplierStockService();
        }

        [HttpGet("{customerId}/{productId}/{quantity}", Name = "GetAddProductToCart")]
        public ProductItemsResult Get(string customerId, string productId, float quantity)
        {
            IAddToShoppingCartHandler addToShoppingCartHandler = new CommonAddToShoppingCartHandler(customerId) { SupplierStockService = SupplierStockService };
            Result result = addToShoppingCartHandler.AddToShoppingCart(productId, quantity);
            if (result == null || (result.Success && !(result.ResultObject is ShoppingCart)))
            {
                return new ProductItemsResult($"Adding product not succesful. Unknown error occured.");
            }
            if (!result.Success)
            {
                var rst = new ProductItemsResult($"Adding product not succesful. {result.GetErrorMessage()}");
                if (result.ResultObject != null && result.ResultObject is ShoppingCart)
                {
                    rst.ApplyProductItems((ShoppingCart)result.ResultObject);
                }
                return rst;
            }
            var rslt = new ProductItemsResult((ShoppingCart)(result.ResultObject))
            {
                Message = MessageConstants.ADDING_PRODUCT_TO_SHOPPING_CART_SUCCESFUL
            };
            return rslt;
        }
    }
}
