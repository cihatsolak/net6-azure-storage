namespace AzureTableStorageWebApp.Controllers
{
    public class PicturesController : Controller
    {
        private readonly INoSqlStorage<UserPicture> _noSqlStorage;
        private readonly IBlobStorage _blobStorage;

        public PicturesController(
            INoSqlStorage<UserPicture> tableStorage,
            IBlobStorage blobStorage)
        {
            _noSqlStorage = tableStorage;
            _blobStorage = blobStorage;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<string> path = new();

            var user = await _noSqlStorage.GetByRowAndPartitionKeyAsync(SampleUserInfo.UserId, SampleUserInfo.City);
            if (user is null)
                throw new Exception("user not found.");

            ViewBag.BlobUrl = user.Paths.Select(blob => new FileBlob
            {
                Name = blob,
                Url = $"{_blobStorage.BlobUrl}/{EContainerName.images}/{blob}"
            }).ToList();

            return View();
        }
    }
}
