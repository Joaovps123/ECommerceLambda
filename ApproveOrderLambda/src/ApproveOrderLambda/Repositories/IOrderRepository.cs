using ECommerceLambda.Domain.Models;

namespace ApproveOrderLambda.Repositories
{
    public interface IOrderRepository
    {
        Task SaveOrder(Order order);
    }
}