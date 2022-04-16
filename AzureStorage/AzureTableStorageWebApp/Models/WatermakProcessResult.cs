namespace AzureTableStorageWebApp.Models
{
    public class WatermakProcessResult
    {
        public WatermakProcessResult(bool succedeed, string message)
        {
            Succedeed = succedeed;
            Message = message;
        }

        public bool Succedeed { get; set; }
        public string Message { get; set; }
    }
}
