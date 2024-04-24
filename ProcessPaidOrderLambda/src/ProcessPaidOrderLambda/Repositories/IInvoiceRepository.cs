using ECommerceLambda.Domain.Models;

namespace ProcessPaidOrderLambda.Repositories
{
    public interface IInvoiceRepository
    {
        Task SaveInvoice(Invoice invoice);
    }
}