using ECommerceLambda.Domain.Models;

namespace ECommerceLambda.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(string document);
        Task Create(Customer customer);
        Task Update(Customer customer);
        Task Delete(string document);
    }
}