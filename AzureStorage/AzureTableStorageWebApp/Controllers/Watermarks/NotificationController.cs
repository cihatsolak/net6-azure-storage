namespace AzureTableStorageWebApp.Controllers.Watermarks
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IWatermarkHubDispatcher _watermarkHubDispatcher;

        public NotificationController(IWatermarkHubDispatcher watermarkHubDispatcher)
        {
            _watermarkHubDispatcher = watermarkHubDispatcher;
        }

        [HttpGet("{connectionId}")]
        public async Task<IActionResult> CompleteWatermakProcess(string connectionId)
        {
            WatermakProcessResult watermakProcessResult = new(true, "Filigran ekleme işlemi başarıyla tamamlandı.");
            await _watermarkHubDispatcher.SendNotifyCompleteWatermakProcessAsync(connectionId, watermakProcessResult);

            return Ok();
        }
    }
}
