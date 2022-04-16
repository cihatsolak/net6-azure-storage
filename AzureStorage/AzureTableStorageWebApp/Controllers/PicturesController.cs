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
            var user = await _noSqlStorage.GetByRowAndPartitionKeyAsync(SampleUserInfo.UserId, SampleUserInfo.City);
            if (user is null)
                return View();

            if (user.Paths is not null)
            {
                var fileBlobs = user.Paths.Select(blob => new FileBlob
                {
                    Name = blob,
                    Url = $"{_blobStorage.BlobUrl}/{EContainerName.images}/{blob}"
                }).ToList();

                ViewBag.BlobUrl = fileBlobs;
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IEnumerable<IFormFile> imageFormFiles)
        {
            List<string> imageNames = new();

            foreach (var imageFormFile in imageFormFiles)
            {
                string randomFileName = $"{Guid.NewGuid()}{Path.GetExtension(imageFormFile.FileName)}";
                imageNames.Add(randomFileName);

                await _blobStorage.UploadAsync(imageFormFile.OpenReadStream(), randomFileName, EContainerName.images);
            }

            var userPicture = await _noSqlStorage.GetByRowAndPartitionKeyAsync(SampleUserInfo.UserId, SampleUserInfo.City);
            if (userPicture is null)
            {
                userPicture = new()
                {
                    RowKey = SampleUserInfo.UserId,
                    PartitionKey = SampleUserInfo.City,
                    Paths = imageNames
                };
            }
            else
            {
                //if (.Any)
                //{
                //    imageNames.AddRange()
                //}
            }

            await _noSqlStorage.AddAsync(userPicture);

            return RedirectToAction(nameof(Index));
        }
    }
}
