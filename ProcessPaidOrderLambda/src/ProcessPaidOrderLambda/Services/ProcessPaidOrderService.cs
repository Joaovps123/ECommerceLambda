using ECommerceLambda.Domain.Models;
using ProcessPaidOrderLambda.Repositories;

namespace ProcessPaidOrderLambda.Services
{
    public class ProcessPaidOrderService : IProcessPaidOrderService
    {
        private readonly IStorageService _storageService;
        private readonly IInvoiceRepository _repository;

        public ProcessPaidOrderService(IStorageService storageService, IInvoiceRepository repository)
        {
            _storageService = storageService;
            _repository = repository;
        }

        public async Task Process(Order order)
        {
            var invoice = new Invoice()
            {
                CustomerDocument = order.CustomerDocument,
                InvoiceId = Guid.NewGuid().ToString(),
                CalculationBase = order.TotalPrice,
                TaxRate = 20,
                Description = $"Invoice related to order {order.OrderId}"
            };

            await _storageService.SaveInvoice(invoice);
            await _repository.SaveInvoice(invoice);
        }
    }
}