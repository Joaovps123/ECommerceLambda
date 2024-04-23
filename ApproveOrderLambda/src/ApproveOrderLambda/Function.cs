using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.SQS;
using ApproveOrderLambda.Repositories;
using ApproveOrderLambda.Services;
using ECommerceLambda.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApproveOrderLambda
{
    public class Function
    {
        private readonly IApproveOrderService _service;

        public Function()
        {
            var _serviceCollection = new ServiceCollection();
            _serviceCollection.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
            _serviceCollection.AddScoped<IDynamoDBContext, DynamoDBContext>();
            _serviceCollection.AddScoped<IApproveOrderService, ApproveOrderService>();
            _serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            _serviceCollection.AddScoped<IAmazonSQS, AmazonSQSClient>();
            _serviceCollection.AddScoped<IMessageService, MessageService>();

            var serviceProvider = _serviceCollection.BuildServiceProvider();

            _service = serviceProvider.GetRequiredService<IApproveOrderService>();
        }

        public async Task FunctionHandler(SQSEvent input, ILambdaContext context)
        {
            foreach (var message in input.Records)
            {
                await ProcessMessages(message, context);
            }
        }

        private async Task ProcessMessages(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            context.Logger.Log("Message");
            context.Logger.Log(JsonSerializer.Serialize(message));
            context.Logger.Log("ApproximateReceiveCount");
            context.Logger.Log(message.Attributes["ApproximateReceiveCount"]);
            context.Logger.Log("Body");
            context.Logger.Log(message.Body);

            var order = JsonSerializer.Deserialize<Order>(message.Body);
            await _service.ApproveOrder(order);

            await Task.CompletedTask;
        }
    }
}