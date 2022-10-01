namespace IECommerceDAO
{
    public interface IECommerceDAOFactory
    {
        ICustomerDAO CustomerDAO { get; }
        IOrderDAO OrderDAO { get; }
        IProductDAO ProductDAO { get; }
        ILocalStockDAO LocalStockDAO { get; }
        ISupplierStockDAO SupplierStockDAO { get; }

        ICommonDAO CommonDAO { get; }
    }
}
