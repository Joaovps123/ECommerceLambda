using ECommerceLambda.Domain.Models;
using ECommerceLambda.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _service;

        public OrderController(ILogger<OrderController> logger, IOrderService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(Order order)
        {
            _logger.LogInformation("Order sent to queue.");
            await _service.SendOrder(order);
            return Ok();
        }
    }
}