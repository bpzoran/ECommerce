using IECommerceBO.DiscountBO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO.OrderBO.DiscountBO
{
    public class PhoneNumberDiscount : Discount
    {
        private readonly string phoneNumber;
        public PhoneNumberDiscount(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public override float GetDiscountPercentage()
        {
            string sPhoneNumberEnd = PhoneNumberEnd();
            if (!int.TryParse(sPhoneNumberEnd, out int nPhoneNumberEnd))
            {
                return 0;
            }
            if (nPhoneNumberEnd == 0)
            {
                return 30;
            }
            if (nPhoneNumberEnd % 2 == 0)
            {
                return 20;
            }
            else
            {
                return 10;
            }
        }

        private string PhoneNumberEnd()
        {
            return this.phoneNumber[phoneNumber.Length - 1].ToString();
        }
    }
}
