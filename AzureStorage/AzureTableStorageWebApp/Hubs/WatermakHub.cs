namespace AzureTableStorageWebApp.Hubs
{
    public class WatermakHub : Hub<IWatermakHub>
    {
        public async Task NotifyCompleteWatermakProcess(string connectionId, WatermakProcessResult watermakProcessResult)
        {
            await Clients.Client(connectionId).NotifyCompleteWatermakProcess(watermakProcessResult);
        }
    }
}
