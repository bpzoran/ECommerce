using DBMock.MockingData;
using ECommerceBO;
using ECommerceWebAPI.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceWebAPITest
{
    public class ListCartContentTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Initializer.Initialize();
        }

        [Test]
        public void ListCartContentTest1()
        {
            var dataMocker = new DataMocker() { Price = 10f, ShoppingCartQuantity = 2f };
            dataMocker.InsertDBData();
            dataMocker.InsertShoppingCarts();
            var controller = new ListCartContentController();
            var result = controller.Get("1");
            Assert.AreEqual(result.ProductItems.Count, 3);
            float totalPrice = 0f;
            result.ProductItems.ForEach(t => totalPrice += t.Quantity * t.UnitPrice);
            Assert.AreEqual(totalPrice, 60);
        }
    }
}
