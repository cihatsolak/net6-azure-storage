namespace AzureTableStorageWebApp.Hubs
{
    public interface IWatermarkHubDispatcher
    {
        Task SendNotifyCompleteWatermakProcessAsync(string connectionId, WatermakProcessResult watermakProcessResult);
    }
}
