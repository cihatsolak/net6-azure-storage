namespace AzureTableStorageWebApp.Hubs
{
    public class WatermarkHubDispatcher : IWatermarkHubDispatcher
    {
        private readonly IHubContext<WatermakHub> _hubContext;

        public WatermarkHubDispatcher(IHubContext<WatermakHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotifyCompleteWatermakProcessAsync(string connectionId, WatermakProcessResult watermakProcessResult)
        {
            await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveCompleteWatermarkProcess", watermakProcessResult);
        }
    }
}
