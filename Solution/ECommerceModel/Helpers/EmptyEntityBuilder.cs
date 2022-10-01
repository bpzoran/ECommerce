using ECommerceModel.ECommerceException;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel.Helpers
{
    public class EmptyEntityBuilder
    {
        private static readonly Lazy<EmptyEntityBuilder> instance = new Lazy<EmptyEntityBuilder>(() => new EmptyEntityBuilder());
        public static EmptyEntityBuilder Instance { get { return instance.Value; } }
        private EmptyEntityBuilder() { }

        public T GetEmptyEntity<T>() where T : Entity
        {
            var tType = typeof(T);
            if (tType == typeof(Customer))
            {
                return new Customer() as T;
            }
            else if (tType == typeof(Order))
            {
                return new Order() as T;
            }
            else if (tType == typeof(Product))
            {
                return new Product() as T;
            }
            else if (tType == typeof(ShoppingCart))
            {
                return new ShoppingCart() as T;
            }
            else if (tType == typeof(LocalStock))
            {
                return new LocalStock() as T;
            }
            else if (tType == typeof(SupplierStock))
            {
                return new SupplierStock() as T;
            }
            throw new UnknownModelException();
        }
    }
}
