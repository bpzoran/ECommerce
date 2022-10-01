using ECommerceModel.ECommerceComparing;
using System;

namespace ECommerceModel
{
    public class Product : Entity
    {
        public Product()
        {
        }

        public Product(string productName)
        {
            this.ProductName = productName;
        }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }

        public Supplier Supplier { get; set; }

        public override object GetId()
        {
            return ProductId;
        }

        public override bool Equals(object obj)
        {
            if (this == (Product)obj)
            {
                return true;
            }
            return ComparerFactory.Instance.GetComparer<Product>().Compare(this, (Product)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }
    }
}
