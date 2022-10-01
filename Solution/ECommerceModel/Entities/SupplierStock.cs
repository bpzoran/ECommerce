using ECommerceModel.ECommerceComparing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel
{
    public class SupplierStock: Stock
    {
        public Supplier Supplier { get; set; }
        public string WebServiceURL { get; set; }


        public override bool Equals(object obj)
        {
            ComparerFactory.Instance.GetComparer<SupplierStock>().IgnoreMember("ProductStocks");
            return ComparerFactory.Instance.GetComparer<SupplierStock>().Compare(this, (SupplierStock)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }
    }
}
