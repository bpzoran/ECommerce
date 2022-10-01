using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceBO.ProductBO;
using ECommerceWebAPI.WebAPIModel;
using IECommerceBO.ProductBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ProductsResult Get()
        {
            IProductListingHandler productListingHandler = new ProductListingHandler();
            return new ProductsResult(productListingHandler.GetAllProducts());
        }
    }
}
