using ECommerceLambda.Domain.Models;

namespace ECommerceLambda.Service
{
    public interface IOrderService
    {
        Task SendOrder(Order order);
    }
}