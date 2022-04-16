namespace AzureTableStorageWebApp.Hubs
{
    public interface IWatermakHub
    {
        Task NotifyCompleteWatermakProcess(WatermakProcessResult watermakProcessResult);
    }
}
