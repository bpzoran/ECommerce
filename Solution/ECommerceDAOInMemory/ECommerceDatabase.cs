using ECommerceModel;
using ECommerceModel.ECommerceException;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDAOInMemory
{
    public class ECommerceDatabase
    {


        private static readonly Lazy<ECommerceDatabase> instance = new Lazy<ECommerceDatabase>(() => new ECommerceDatabase());
        public static ECommerceDatabase Instance { get { return instance.Value; } }

        public ConcurrentDictionary<object, Customer> Customers { get; private set; }
        public ConcurrentDictionary<object, Order> Orders { get; private set; }
        public ConcurrentDictionary<object, Product> Products { get; private set; }
        public ConcurrentDictionary<object, ShoppingCart> ShoppingCarts { get; private set; }
        public ConcurrentDictionary<object, LocalStock> LocalStocks { get; private set; }
        public ConcurrentDictionary<object, SupplierStock> SupplierStocks { get; private set; }

        private ECommerceDatabase()
        {
            Customers = new ConcurrentDictionary<object, Customer>();
            Orders = new ConcurrentDictionary<object, Order>();
            Products = new ConcurrentDictionary<object, Product>();
            ShoppingCarts = new ConcurrentDictionary<object, ShoppingCart>();
            LocalStocks = new ConcurrentDictionary<object, LocalStock>();
            SupplierStocks = new ConcurrentDictionary<object, SupplierStock>();
        }

        public ConcurrentDictionary<object, TEntity> Set<TEntity>() where TEntity : Entity
        {
            var typeOfEntity = typeof(TEntity);
            if (typeOfEntity == typeof(Customer))
            {
                return Customers as ConcurrentDictionary<object, TEntity>;
            }
            else if (typeOfEntity == typeof(Order))
            {
                return Orders as ConcurrentDictionary<object, TEntity>;
            }
            else if (typeOfEntity == typeof(Product))
            {
                return Products as ConcurrentDictionary<object, TEntity>;
            }
            else if (typeOfEntity == typeof(ShoppingCart))
            {
                return ShoppingCarts as ConcurrentDictionary<object, TEntity>;
            }
            else if (typeOfEntity == typeof(LocalStock))
            {
                return LocalStocks as ConcurrentDictionary<object, TEntity>;
            }
            else if (typeOfEntity == typeof(SupplierStock))
            {
                return SupplierStocks as ConcurrentDictionary<object, TEntity>;
            }
            throw new UnknownModelException();
        }

        public void Clear()
        {
            Customers.Clear();
            Orders.Clear();
            Products.Clear();
            ShoppingCarts.Clear();
            LocalStocks.Clear();
            SupplierStocks.Clear();
        }
    }
}
