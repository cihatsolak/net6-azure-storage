namespace AzureStorageLibrary.Infrastructure
{
    public enum EContainerName
    {
        Image,
        Pdf,
        Office,
        Video,
        Log
    }

    public interface IBlobStorage
    {
        string BlobUrl { get; set; }
        List<string> GetNames(EContainerName eContainerName);
        Task UploadAsync(Stream fileStrem, string fileName, EContainerName eContainerName);
        Task<Stream> DownloadAsync(string fileName, EContainerName eContainerName);
        Task DeleteAsync(string fileName);
        Task AddLogAsync(string text, string fileName);
        Task<List<string>> GetLogsAsync(string fileName);
    }
}
