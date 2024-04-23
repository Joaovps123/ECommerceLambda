using ECommerceLambda.Domain.Models;

namespace ApproveOrderLambda.Services
{
    public interface IMessageService
    {
        Task SendMessage(Order order);
    }
}