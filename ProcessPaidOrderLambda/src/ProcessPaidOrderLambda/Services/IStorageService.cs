using ECommerceLambda.Domain.Models;

namespace ProcessPaidOrderLambda.Services
{
    public interface IStorageService
    {
        Task SaveInvoice(Invoice invoice);
    }
}