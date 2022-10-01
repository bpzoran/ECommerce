using ECommerceDAOAbstractFactory;
using ECommerceDAOInMemory;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceBO
{
    public class Initializer
    {
        public static void Initialize()
        {
            DAOAbstractFactory.Instance.DAOFactory = new ECommerceDAOInMemoryFactory();
        }
    }
}
