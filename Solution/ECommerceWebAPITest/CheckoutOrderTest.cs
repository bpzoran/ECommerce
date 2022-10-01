using DBMock.MockingData;
using ECommerceBO;
using ECommerceWebAPI.Controllers;
using IECommerceBO.TimeAssignBO;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceWebAPITest
{
    public class CheckoutOrderTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Initializer.Initialize();
        }

        [Test]
        public void CheckoutOrderTest1()
        {
            var dataMocker = new DataMocker() { Price = 10f, ShoppingCartQuantity = 2f, PhoneNumber = "+38164123657" };
            dataMocker.InsertDBData();
            dataMocker.InsertShoppingCarts();
            Mock<ITimeAssigner> timeAssignerMock = new Mock<ITimeAssigner>();
            timeAssignerMock.Setup(t => t.DateTime).Returns(new DateTime(2022, 10, 1, 10, 0, 0));
            var controller = new CheckoutOrderController
            {
                TimeAssigner = timeAssignerMock.Object
            };
            var result = controller.Get("1");
            Assert.AreEqual(result.TotalAmount, 60f);
            timeAssignerMock.Setup(t => t.DateTime).Returns(new DateTime(2022, 10, 1, 16, 30, 0));
            result = controller.Get("2");
            Assert.AreEqual(result.TotalAmount, 54f);
        }

        [Test]
        public void CheckoutOrderTest2()
        {
            var dataMocker = new DataMocker() { Price = 10f, ShoppingCartQuantity = 2f, PhoneNumber = "+38164123658" };
            dataMocker.InsertDBData();
            dataMocker.InsertShoppingCarts();
            Mock<ITimeAssigner> timeAssignerMock = new Mock<ITimeAssigner>();
            timeAssignerMock.Setup(t => t.DateTime).Returns(new DateTime(2022, 10, 1, 10, 0, 0));
            var controller = new CheckoutOrderController
            {
                TimeAssigner = timeAssignerMock.Object
            };
            var result = controller.Get("1");
            Assert.AreEqual(result.TotalAmount, 60f);
            timeAssignerMock.Setup(t => t.DateTime).Returns(new DateTime(2022, 10, 1, 16, 30, 0));
            result = controller.Get("2");
            Assert.AreEqual(result.TotalAmount, 48f);
        }

        [Test]
        public void CheckoutOrderTest3()
        {
            var dataMocker = new DataMocker() { Price = 10f, ShoppingCartQuantity = 2f };
            dataMocker.InsertDBData();
            dataMocker.InsertShoppingCarts();
            Mock<ITimeAssigner> timeAssignerMock = new Mock<ITimeAssigner>();
            var controller = new CheckoutOrderController
            {
                TimeAssigner = timeAssignerMock.Object
            };
            timeAssignerMock.Setup(t => t.DateTime).Returns(new DateTime(2022, 10, 1, 16, 30, 0));
            var result = controller.Get("1", "Novi Sad", "Jiricekova", "2", "+3816436526");
            Assert.AreEqual(result.TotalAmount, 48f);
            result = controller.Get("2", "Novi Sad", "Jiricekova", "2", "+3816436527");
            Assert.AreEqual(result.TotalAmount, 54f);
            result = controller.Get("3", "Novi Sad", "Jiricekova", "2", "+3816436520");
            Assert.AreEqual(result.TotalAmount, 42f);
        }


    }
}
