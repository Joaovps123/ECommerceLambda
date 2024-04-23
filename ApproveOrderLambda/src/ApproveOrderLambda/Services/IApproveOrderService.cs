using ECommerceLambda.Domain.Models;

namespace ApproveOrderLambda.Services
{
    public interface IApproveOrderService
    {
        Task ApproveOrder(Order order);
    }
}