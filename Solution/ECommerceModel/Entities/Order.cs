using ECommerceModel.ECommerceComparing;
using ECommerceModel.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel
{
    public class Order : Entity
    {
       public Order()
        {
            this.OrderTime = DateTime.Now;
            this.Items = new List<ProductItem>();
            this.OrderId = Guid.NewGuid().ToString();
        }
        public Customer Customer { get; set; }

        public string OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public float InitialTotalPrice { get; set; }
        public float FinalTotalPrice { get; set; }
        public float AppliedDiscount { get; set; }
        public string ProceedingCity { get; set; }
        public string ProceedingStreet { get; set; }
        public string ProceedingHouseNumber { get; set; }
        public string ProceedingPhoneNumber { get; set; }

        public List<ProductItem> Items { get; set; }


        public override object GetId()
        {
            return OrderId;
        }

        public void Apply(ProceedingData proceedingData)
        {
            this.ProceedingCity = proceedingData.ProceedingCity;
            this.ProceedingHouseNumber = proceedingData.ProceedingHouseNumber;
            this.ProceedingPhoneNumber = proceedingData.ProceedingPhoneNumber;
            this.ProceedingStreet = proceedingData.ProceedingStreet;
        }

        public override bool Equals(object obj)
        {
            if (this == (Order)obj)
            {
                return true;
            }
            return ComparerFactory.Instance.GetComparer<Order>().Compare(this, (Order)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }
    }
}
