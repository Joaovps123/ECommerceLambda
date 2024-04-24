using Amazon.S3;
using Amazon.S3.Model;

namespace ECommerceLambda.Service
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _client;

        public StorageService(IAmazonS3 client)
        {
            _client = client;
        }

        public async Task<byte[]> DownloadFile(string fileKey)
        {
            MemoryStream? stream = null;
            string bucketName = ""; // Bucket Name
            var request = new GetObjectRequest { BucketName = bucketName, Key = fileKey };
            var response = await _client.GetObjectAsync(request);

            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                using (stream = new MemoryStream())
                {
                    await response.ResponseStream.CopyToAsync(stream);
                    return stream.ToArray();
                }
            }
            else
                throw new FileNotFoundException($"The file {fileKey} does not exist.");
        }
    }
}