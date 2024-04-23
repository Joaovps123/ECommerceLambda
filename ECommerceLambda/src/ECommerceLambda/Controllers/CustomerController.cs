using ECommerceLambda.Models;
using ECommerceLambda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _repository;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{document}")]
        public async Task<IActionResult> Get(string document)
        {
            return Ok(await _repository.Get(document));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _repository.Create(customer);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Customer customer)
        {
            await _repository.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{document}")]
        public async Task<IActionResult> Delete(string document)
        {
            await _repository.Delete(document);
            return Ok();
        }
    }
}