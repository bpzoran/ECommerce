using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel.ECommerceException
{
    public class ECommercelException : Exception
    {
        public ECommercelException(string message) : base(message)
        {
        }
    }
}
