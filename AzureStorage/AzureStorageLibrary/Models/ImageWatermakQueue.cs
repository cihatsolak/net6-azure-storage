namespace AzureStorageLibrary.Models
{
    public class ImageWatermakQueue
    {
        public string UserId { get; set; }
        public string ConnectionId { get; set; }
        public string City { get; set; }
        public string WatermakText { get; set; }
        public List<string> Images { get; set; }
    }
}
