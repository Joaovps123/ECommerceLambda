using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Models;

namespace ECommerceLambda.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDynamoDBContext _context;

        public CustomerRepository(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<Customer> Get(string document)
        {
            return await _context.LoadAsync<Customer>(document);
        }

        public async Task Create(Customer customer)
        {
            await _context.SaveAsync(customer);
        }

        public async Task Update(Customer customer)
        {
            await _context.SaveAsync(customer);
        }

        public async Task Delete(string document)
        {
            await _context.DeleteAsync<Customer>(document);
        }
    }
}