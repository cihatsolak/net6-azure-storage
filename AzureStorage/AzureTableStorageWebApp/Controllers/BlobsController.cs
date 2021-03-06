namespace AzureTableStorageWebApp.Controllers
{
    public class BlobsController : Controller
    {
        private readonly IBlobStorage _blobStorage;

        public BlobsController(IBlobStorage blobStorage)
        {
            _blobStorage = blobStorage;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var names = _blobStorage.GetNames(EContainerName.images);

            ViewBag.FileBlobs = names.Select(name => new FileBlob
            {
                Name = name,
                Url = string.Concat(_blobStorage.BlobUrl, "/", EContainerName.images.ToString(), "/", name)
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile formfile)
        {
            string fileName = string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(formfile.FileName));
            await _blobStorage.UploadAsync(formfile.OpenReadStream(), fileName, EContainerName.images);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var stream = await _blobStorage.DownloadAsync(fileName, EContainerName.images);
            return File(stream, "application/octet-stream", fileName);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string fileName)
        {
            await _blobStorage.DeleteAsync(fileName, EContainerName.images);
            return RedirectToAction(nameof(Index));
        }
    }
}
