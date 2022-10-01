using ECommerceModel.ECommerceComparing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel
{
    public class Supplier: Entity
    {
        public string SupplierId { get; set; }
        public string SupplierName { get; set; }

        public override object GetId()
        {
            return SupplierId;
        }

        public override bool Equals(object obj)
        {
            if (this == (Supplier)obj)
            {
                return true;
            }
            return ComparerFactory.Instance.GetComparer<Supplier>().Compare(this, (Supplier)obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }
    }
}
