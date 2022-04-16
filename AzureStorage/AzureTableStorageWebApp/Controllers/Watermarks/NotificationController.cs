namespace AzureTableStorageWebApp.Controllers.Watermarks
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly WatermakHub _watermakMarkHub;

        public NotificationController(WatermakHub wateraMarkHub)
        {
            _watermakMarkHub = wateraMarkHub;
        }

        public async Task<IActionResult> CompleteWatermakProcess(string connectionId)
        {
            WatermakProcessResult watermakProcessResult = new(true, "Filigran ekleme işlemi başarıyla tamamlandı.");
            await _watermakMarkHub.NotifyCompleteWatermakProcess(connectionId, watermakProcessResult);

            return Ok();
        }
    }
}
