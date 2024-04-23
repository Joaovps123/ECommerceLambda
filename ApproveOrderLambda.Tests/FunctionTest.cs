using Amazon.Lambda.SQSEvents;
using Amazon.Lambda.TestUtilities;
using Amazon.Runtime.Internal.Transform;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace ApproveOrderLambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async void Should_save_a_order_with_success()
        {
            Order order = new Order
            {
                Status = StatusOrderEnum.AWAITING_PAYMENT,
                OrderId = Guid.NewGuid(),
                Customer = new Customer
                {
                    Document = "12345678900",
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Address = new Address
                    {
                        Street = "123 Main St",
                        Number = 456,
                        Complement = "Apt 101",
                        City = "Anytown",
                        State = "ST"
                    }
                },
                OrderItems = new List<OrderItem>
                {
                    new OrderItem { Quantity = 2, UnitPrice = 10.99m, ProductId = 123 },
                    new OrderItem { Quantity = 1, UnitPrice = 29.99m, ProductId = 456 }
                }
            };

            var input = new SQSEvent()
            {
                Records = new List<SQSEvent.SQSMessage>()
                {
                    new SQSEvent.SQSMessage()
                    { 
                        Body = JsonSerializer.Serialize(order),
                        Attributes = new Dictionary<string, string>()
                        {
                            { "ApproximateReceiveCount", "1" }
                        }
                    }
                }
            };
            var context = new TestLambdaContext() { Logger = new TestLambdaLogger() };

            var function = new Function();
            await function.FunctionHandler(input, context);

            // asserts
        }
    }
}