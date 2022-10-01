using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel.Helpers
{
    public class ProceedingData
    {
        public string ProceedingCity { get; set; }
        public string ProceedingStreet { get; set; }
        public string ProceedingHouseNumber { get; set; }
        public string ProceedingPhoneNumber { get; set; }

        public ProceedingData(string proceedingCity, string proceedingStreet, string proceedingHouseNumber, string proceedingPhoneNumber)
        {
            this.ProceedingCity = proceedingCity;
            this.ProceedingStreet = proceedingStreet;
            this.ProceedingHouseNumber = proceedingHouseNumber;
            this.ProceedingPhoneNumber = proceedingPhoneNumber;
        }

        public ProceedingData()
        {
            this.ProceedingCity = string.Empty;
            this.ProceedingStreet = string.Empty;
            this.ProceedingHouseNumber = string.Empty;
            this.ProceedingPhoneNumber = string.Empty;
        }

    }
}
