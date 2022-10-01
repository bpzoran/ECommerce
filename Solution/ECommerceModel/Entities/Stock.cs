using ECommerceModel.ECommerceComparing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel
{
    public abstract class Stock : Entity
    {
        public Stock()
        {
            ProductStocks = new List<ProductStock>();
        }
        
        public int StockId { get; set; }
        public string StockName { get; set; }

        public bool IsDefault { get; set; }
        public List<ProductStock> ProductStocks { get; set; }

        public override object GetId()
        {
            return StockId;
        }        
    }
}
