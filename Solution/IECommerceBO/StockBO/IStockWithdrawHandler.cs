using ECommerceModel;
using ECommerceModel.Results;
using System;

namespace IECommerceBO.StockBO
{
    public interface IStockWithdrawHandler
    {
        void WithdrawProduct(Product product, float quantity, out float missingQuantity, Result result);

    }
}
