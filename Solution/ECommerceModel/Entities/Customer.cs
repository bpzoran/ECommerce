using ECommerceModel.ECommerceComparing;
using ECommerceModel.Helpers;
using ObjectsComparer;
using System;
using System.Text;

namespace ECommerceModel
{
    public class Customer: Entity
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public Customer(Customer customer): this() {
            this.CustomerId = customer.CustomerId;
            this.FirstName = customer.FirstName;
            this.LastName = customer.LastName;
            this.City = customer.City;
            this.Street = customer.Street;
            this.HouseNumber = customer.HouseNumber;
            this.PhoneNumber = customer.PhoneNumber;
        }

        public Customer(ProceedingData customer) : this()
        {
            this.City = customer.ProceedingCity;
            this.Street = customer.ProceedingStreet;
            this.HouseNumber = customer.ProceedingHouseNumber;
            this.PhoneNumber = customer.ProceedingPhoneNumber;
        }



        public Customer()
        {
            this.ShoppingCart = new ShoppingCart();
        }

        public override object GetId()
        {
            return CustomerId;
        }

        public override bool Equals(object obj)
        {
            if (this == (Customer)obj)
            {
                return true;
            }
            return ComparerFactory.Instance.GetComparer<Customer>().Compare(this, (Customer)obj);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }
    }
}
