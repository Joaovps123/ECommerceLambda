using ECommerceLambda.Models;

namespace ECommerceLambda.Service
{
    public interface IOrderService
    {
        Task SendOrder(Order order);
    }
}