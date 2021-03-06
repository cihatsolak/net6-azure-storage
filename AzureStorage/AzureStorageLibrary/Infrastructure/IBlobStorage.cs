namespace AzureStorageLibrary.Infrastructure
{
    public enum EContainerName
    {
        images,
        watermarks,
        documents,
        videos,
        log
    }

    public interface IBlobStorage
    {
        string BlobUrl { get; }
        List<string> GetNames(EContainerName eContainerName);
        Task UploadAsync(Stream fileStrem, string fileName, EContainerName eContainerName);
        Task<Stream> DownloadAsync(string fileName, EContainerName eContainerName);
        Task DeleteAsync(string fileName, EContainerName eContainerName);
        Task AddLogAsync(string text, string fileName);
        Task<List<string>> GetLogsAsync(string fileName);
    }
}
