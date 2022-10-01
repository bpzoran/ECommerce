using DBMock.MockingData;
using ECommerceBO;
using ECommerceWebAPI.Constants;
using ECommerceWebAPI.Controllers;
using ECommerceWebAPI.WebAPIModel;
using IECommerceBO.SupplierBO;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace ECommerceWebAPITest
{
    public class AddProductToCartTest
    {
        private Mock<ISupplierStockService> supplierServiceStockMock;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Initializer.Initialize();
        }

        [SetUp]
        public void Setup()
        {
            (new DataMocker() { ProductQuantityOnStock = 50 }).InsertDBData();
            supplierServiceStockMock = new Mock<ISupplierStockService>();
            supplierServiceStockMock.Setup(t => t.AddProduct(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            supplierServiceStockMock.Setup(t => t.WithdrawProduct(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<float>())).Returns(true);
            supplierServiceStockMock.Setup(t => t.UpdateProduct(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<float>())).Returns(true);
        }

        [Test]
        public void AddProductTest1()
        {
            supplierServiceStockMock.Setup(t => t.GetQuantity(It.IsAny<string>(), It.IsAny<string>())).Returns(25);
            var controller = new AddProductToCartController() { SupplierStockService = supplierServiceStockMock.Object };
            ProductItemsResult response;
            response = controller.Get("1", "1", 20f);
            Assert.AreEqual(response.ProductItems.Where(t => t.ProductId == "1").FirstOrDefault().Quantity, 20f);
            Assert.AreEqual(response.Message, MessageConstants.ADDING_PRODUCT_TO_SHOPPING_CART_SUCCESFUL);
            response = controller.Get("1", "1", 35f);            
            Assert.AreEqual(response.ProductItems.Where(t => t.ProductId == "1").FirstOrDefault().Quantity, 55f);
            Assert.AreEqual(response.Message, MessageConstants.ADDING_PRODUCT_TO_SHOPPING_CART_SUCCESFUL);
            supplierServiceStockMock.Setup(t => t.GetQuantity(It.IsAny<string>(), It.IsAny<string>())).Returns(20);
            response = controller.Get("1", "1", 30f);
            Assert.AreEqual(response.ProductItems.Where(t => t.ProductId == "1").FirstOrDefault().Quantity, 55f);
            Assert.AreNotEqual(response.Message, MessageConstants.ADDING_PRODUCT_TO_SHOPPING_CART_SUCCESFUL);
            response = controller.Get("1", "1", 20f);
            supplierServiceStockMock.Setup(t => t.GetQuantity(It.IsAny<string>(), It.IsAny<string>())).Returns(0);
            Assert.AreEqual(response.ProductItems.Where(t => t.ProductId == "1").FirstOrDefault().Quantity, 75f);
            Assert.AreEqual(response.Message, MessageConstants.ADDING_PRODUCT_TO_SHOPPING_CART_SUCCESFUL);
            response = controller.Get("1", "1", 1f);
            Assert.AreEqual(response.ProductItems.Where(t => t.ProductId == "1").FirstOrDefault().Quantity, 75f);
            Assert.AreNotEqual(response.Message, MessageConstants.ADDING_PRODUCT_TO_SHOPPING_CART_SUCCESFUL);
        }
    }
}