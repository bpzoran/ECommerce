using ECommerceModel.ECommerceComparing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel
{
    public class LocalStock: Stock
    {
        public float Capacity { get; set; }
        public string Address { get; set; }
        public override bool Equals(object obj)
        {
            
            return ComparerFactory.Instance.GetComparer<LocalStock>().Compare(this, (LocalStock)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }
    }
}
