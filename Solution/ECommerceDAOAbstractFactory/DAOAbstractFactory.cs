using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDAOAbstractFactory
{
    public class DAOAbstractFactory
    {
        private static readonly Lazy<DAOAbstractFactory> instance = new Lazy<DAOAbstractFactory>(() => new DAOAbstractFactory());
        public static DAOAbstractFactory Instance { get { return instance.Value; } }
        public IECommerceDAOFactory DAOFactory { get; set; }
        private DAOAbstractFactory() { }
    }
}
