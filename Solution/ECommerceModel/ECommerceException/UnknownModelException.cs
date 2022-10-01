using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceModel.ECommerceException
{
    public class UnknownModelException : Exception
    {
        public static readonly string ERROR_MESSAGE = "Unknown model type";
        public UnknownModelException() : base(ERROR_MESSAGE)
        {
        }
    }
}
