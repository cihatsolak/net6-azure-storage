namespace AzureStorageLibrary.Infrastructure
{
    public interface IQueueStorage
    {
        Task SendMessageAsync(string message);
        Task<QueueMessage> RetrieveNextMessageAsync();
        Task DeleteMessageAsync(string messageId, string popReceipt);
    }
}
