using ApproveOrderLambda.Repositories;
using ECommerceLambda.Domain.Models;

namespace ApproveOrderLambda.Services
{
    public class ApproveOrderService : IApproveOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMessageService _messageService;

        public ApproveOrderService(IOrderRepository repository, IMessageService messageService)
        {
            _repository = repository;
            _messageService = messageService;
        }

        public async Task ApproveOrder(Order order)
        {
            if (order == null)
                throw new Exception("Order is required");
            if (order.Customer == null)
                throw new Exception("Customer is required");
            if (order.Customer.Address == null)
                throw new Exception("Address is required");

            await _repository.SaveOrder(order);
            await _messageService.SendMessage(order);
        }
    }
}