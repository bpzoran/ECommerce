using IECommerceDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceDAOInMemory
{
    public class ECommerceDAOInMemoryFactory : IECommerceDAOFactory
    {
        public ICustomerDAO CustomerDAO => new CustomerRepo();

        public IOrderDAO OrderDAO => new OrderRepo();

        public IProductDAO ProductDAO => new ProductRepo();


        public ILocalStockDAO LocalStockDAO => new LocalStockRepo();

        public ISupplierStockDAO SupplierStockDAO => new SupplierStockRepo();

        public ICommonDAO CommonDAO => new CommonDAO();
    }
}
