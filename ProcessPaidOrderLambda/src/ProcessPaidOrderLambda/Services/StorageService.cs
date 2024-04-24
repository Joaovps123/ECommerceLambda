using Amazon.S3;
using Amazon.S3.Model;
using ECommerceLambda.Domain.Models;
using System.Text;
using System.Text.Json;

namespace ProcessPaidOrderLambda.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _client;

        public StorageService(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task SaveInvoice(Invoice invoice)
        {
            string prefix = $"{invoice.CustomerDocument}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}";
            string key = $"{prefix}/{Guid.NewGuid()}.json";

            var obj = new PutObjectRequest()
            {
                BucketName = "", // Bucket name
                Key = key,
                ContentType = "application/json",
                InputStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(invoice)))
            };

            await _client.PutObjectAsync(obj);
        }
    }
}