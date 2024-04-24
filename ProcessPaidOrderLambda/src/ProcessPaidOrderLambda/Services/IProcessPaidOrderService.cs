using ECommerceLambda.Domain.Models;

namespace ProcessPaidOrderLambda.Services
{
    public interface IProcessPaidOrderService
    {
        Task Process(Order order);
    }
}