namespace ECommerceLambda.Service
{
    public interface IStorageService
    {
        Task<byte[]> DownloadFile(string fileKey);
    }
}