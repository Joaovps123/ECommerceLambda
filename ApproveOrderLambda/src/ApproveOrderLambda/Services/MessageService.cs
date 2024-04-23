using Amazon.SQS;
using Amazon.SQS.Model;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace ApproveOrderLambda.Services
{
    public class MessageService : IMessageService
    {
        private readonly IAmazonSQS _sqsClient;

        public MessageService(IAmazonSQS sqsClient)
        {
            _sqsClient = sqsClient;
        }

        public async Task SendMessage(Order order)
        {
            var request = new SendMessageRequest()
            {
                MessageBody = JsonSerializer.Serialize(order),
                QueueUrl = "" // SQS URL (order-paid-sqs)
            };
            await _sqsClient.SendMessageAsync(request);
        }
    }
}