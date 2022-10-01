using ECommerceDAOAbstractFactory;
using ECommerceModel;
using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBMock.MockingData
{
    public class DataMocker
    {
        private readonly ICustomerDAO customerDAO;
        private readonly IProductDAO productDAO;
        private readonly ILocalStockDAO localStockDAO;
        private readonly ISupplierStockDAO supplierStockDAO;
        private readonly ICommonDAO commonDAO;

        public DataMocker()
        {
            customerDAO = DAOAbstractFactory.Instance.DAOFactory.CustomerDAO;
            productDAO = DAOAbstractFactory.Instance.DAOFactory.ProductDAO;
            localStockDAO = DAOAbstractFactory.Instance.DAOFactory.LocalStockDAO;
            supplierStockDAO = DAOAbstractFactory.Instance.DAOFactory.SupplierStockDAO;
            commonDAO = DAOAbstractFactory.Instance.DAOFactory.CommonDAO;
            ProductQuantityOnStock = 100;
            ShoppingCartQuantity = 20;
            Price = 10;
            PhoneNumber = "+38165986321";
        }

        public float ProductQuantityOnStock { private get; set; }
        public float ShoppingCartQuantity { private get; set; }
        public float Price { private get; set; }
        public string PhoneNumber { private get; set; }

        public void InsertDBData()
        {
            commonDAO.ClearAll();
            Supplier supplier = NewSupplier("1", "Nike");

            customerDAO.Insert(NewCustomer("1", "John", "Smith", PhoneNumber, "New York", "The street", "2/4"));
            customerDAO.Insert(NewCustomer("2", "Zoran", "Jankovic", PhoneNumber, "Novi Sad", "Toplice Milana", "1"));
            customerDAO.Insert(NewCustomer("3", "Aleksandar", "Mitrovic", PhoneNumber, "London", "North street", "1"));

            productDAO.Insert(NewProduct("1", "Shoes", Price, supplier));
            productDAO.Insert(NewProduct("2", "Sweat Suit", Price, supplier));
            productDAO.Insert(NewProduct("3", "T-Shirt", Price, supplier));

            LocalStock localStock = NewLocalStock(1, "Main stock", "1st street 3", true);
            List<Product> allProducts = productDAO.GetList();
            allProducts.ForEach(t => localStock.ProductStocks.Add(new ProductStock(t, localStock, ProductQuantityOnStock)));
            localStockDAO.Insert(localStock);
            
            SupplierStock supplierStock = NewSupplierStock(1, "Nike B2B", "http:\\nike?product", true);
            supplierStock.Supplier = supplier;
            supplierStockDAO.Insert(supplierStock);
        }

        public void InsertShoppingCarts()
        {
            List<Product> products = productDAO.GetList();
            List<Customer> customers = customerDAO.GetList();
            customers.ForEach(t1 => products.ForEach(t2 => t1.ShoppingCart.Add(new ProductItem(t2, ShoppingCartQuantity))));
        }

        private Customer NewCustomer(string customerId, string firstName, string lastName, string phoneNumber, string city, string street, string houseNumber)
        {
            Customer cust = new Customer
            {
                CustomerId = customerId
            };
            cust.FirstName = firstName;
            cust.LastName = lastName;
            cust.PhoneNumber = phoneNumber;
            cust.City = city;
            cust.Street = street;
            cust.HouseNumber = houseNumber;
            return cust;
        }

        private Product NewProduct(string productId, string productName, float productPrice, Supplier supplier)
        {
            Product product = new Product
            {
                ProductId = productId,
                ProductName = productName,
                ProductPrice = productPrice,
                Supplier = supplier
            };
            return product;
        }

        private LocalStock NewLocalStock(int stockId, string stockName, string address, bool isDefault)
        {
            LocalStock localStock = new LocalStock
            {
                Address = address,
                IsDefault = isDefault,
                StockId = stockId,
                StockName = stockName
            };
            return localStock;
        }

        private SupplierStock NewSupplierStock(int stockId, string stockName, string url, bool isDefault)
        {
            SupplierStock supplierStock = new SupplierStock
            {
                IsDefault = isDefault,
                StockId = stockId,
                StockName = stockName,
                WebServiceURL = url
            };
            return supplierStock;
        }

        private Supplier NewSupplier(string supplierId, string supplierName)
        {
            Supplier supplier = new Supplier
            {
                SupplierId = supplierId,
                SupplierName = supplierName
            };
            return supplier;
        }
    }
}
