using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDAOInMemory
{
    public class CommonDAO : ICommonDAO
    {
        public void ClearAll()
        {
            ECommerceDatabase.Instance.Clear();
        }
    }
}
