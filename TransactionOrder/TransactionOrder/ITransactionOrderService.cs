using System.Threading.Tasks;
using TransactionOrder.Entities;
using TransactionOrder.TransactionOrder.Input;

namespace TransactionOrder.TransactionOrder
{
    public interface ITransactionOrderService
    {
        Task<Product> CreateProduct(CreateProductInput input);
    }
}
