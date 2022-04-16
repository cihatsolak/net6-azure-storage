namespace AzureStorageLibrary.Services
{
    public class BlobStorage : IBlobStorage
    {
        public string BlobUrl => "https://automotivestorageaccount.blob.core.windows.net";

        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorage()
        {
            _blobServiceClient = new(ConnectionStrings.AzureStorageConnectionString);
        }

        public async Task AddLogAsync(string text, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(EContainerName.Log.ToString());
            var appendBlobClient = containerClient.GetBlobClient(fileName);

            using MemoryStream memoryStream = new();
            using StreamWriter streamWriter = new(memoryStream);
            streamWriter.Write($"{DateTime.Now}:{text} \n");
            streamWriter.Flush();
            memoryStream.Position = 0;

            await appendBlobClient.UploadAsync(memoryStream);
        }

        public async Task DeleteAsync(string fileName, EContainerName eContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }

        public async Task<Stream> DownloadAsync(string fileName, EContainerName eContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());

            var blobClient = containerClient.GetBlobClient(fileName);
            if (!await blobClient.ExistsAsync())
            {
            }

            var blobDownloadStreamingResult = await blobClient.DownloadStreamingAsync();

            return blobDownloadStreamingResult.Value.Content;
        }

        public async Task<List<string>> GetLogsAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(EContainerName.Log.ToString());
            var appendBlobClient = containerClient.GetBlobClient(fileName);

            var blobDownloadStreamingResult = await appendBlobClient.DownloadStreamingAsync();

            List<string> logs = new();

            using StreamReader streamReader = new(blobDownloadStreamingResult.Value.Content);

            string line = string.Empty;
            while ((line = streamReader.ReadLine()) != null)
            {
                logs.Add(line);
            }

            return logs;
        }

        public List<string> GetNames(EContainerName eContainerName)
        {
            List<string> blobNames = new();
            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());

            var blobs = containerClient.GetBlobs();

            blobs.ToList().ForEach(blob =>
            {
                blobNames.Add(blob.Name);
            });

            return blobNames;
        }

        public async Task UploadAsync(Stream fileStrem, string fileName, EContainerName eContainerName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(eContainerName.ToString());
            await containerClient.CreateIfNotExistsAsync(); //bu container var mı? yoksa oluştur.

            await containerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer); //container'ı dış dünyaya açıldı, url üzerinden erişilebiliyor olacak.

            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileStrem);
        }
    }
}
