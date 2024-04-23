using Amazon.SQS;
using Amazon.SQS.Model;
using ECommerceLambda.Models;
using System.Text.Json;

namespace ECommerceLambda.Service
{
    public class OrderService : IOrderService
    {
        private readonly IAmazonSQS _sqsClient;

        public OrderService(IAmazonSQS sqsClient) 
        {
            _sqsClient = sqsClient;
        }

        public async Task SendOrder(Order order)
        {
            var request = new SendMessageRequest()
            {
                MessageBody = JsonSerializer.Serialize(order),
                QueueUrl = "" // SQS URL
            };

            await _sqsClient.SendMessageAsync(request);
        }
    }
}