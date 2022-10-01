using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceBO.OrderBO;
using ECommerceModel;
using ECommerceModel.Results;
using ECommerceWebAPI.WebAPIModel;
using IECommerceBO.OrderBO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListCartContentController : ControllerBase
    {
        [HttpGet("{customerId}", Name = "ListCartContentControllerGet")]
        public ProductItemsResult Get(string customerId)
        {
            IListCartContentHandler listCartContentHandler = new ListCartContentHandler();
            Result productItemResult = listCartContentHandler.GetProductItems(customerId);
            object resultObject = productItemResult.ResultObject;
            if (resultObject is null || !(resultObject is List<ProductItem>))
            {
                return new ProductItemsResult("Unknown error");
            }
            return new ProductItemsResult(resultObject as List<ProductItem>);
        }
    }
}
