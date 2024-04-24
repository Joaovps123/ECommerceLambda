using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.S3;
using ECommerceLambda.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using ProcessPaidOrderLambda.Repositories;
using ProcessPaidOrderLambda.Services;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ProcessPaidOrderLambda
{
    public class Function
    {
        private readonly IProcessPaidOrderService _service;

        public Function()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IAmazonS3, AmazonS3Client>();
            serviceCollection.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
            serviceCollection.AddScoped<IDynamoDBContext, DynamoDBContext>();
            serviceCollection.AddScoped<IProcessPaidOrderService, ProcessPaidOrderService>();
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _service = serviceProvider.GetRequiredService<IProcessPaidOrderService>();
        }

        public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
        {
            foreach (var message in evnt.Records)
            {
                await ProcessMessageAsync(message, context);
            }
        }

        private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
        {
            context.Logger.LogInformation($"Processed message {message.Body}");

            var order = JsonSerializer.Deserialize<Order>(message.Body);
            await _service.Process(order);

            await Task.CompletedTask;
        }
    }
}