using IECommerceDAO;
using System;

namespace IECommerceDAOFactory
{
    public interface IECommerceDAOFactory
    {
        ICustomerDAO CustomerDAO { get; set; }
        IOrderDAO OrderDAO { get; set; }
        IProductDAO ProductDAO { get; set; }
        IShoppingCartDAO ShoppingCartDAO { get; set; }
        IStockDAO StockDAO { get; set; }
    }
}
