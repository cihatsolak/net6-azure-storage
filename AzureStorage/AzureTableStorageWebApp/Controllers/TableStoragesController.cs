namespace AzureTableStorageWebApp.Controllers
{
    public class TableStoragesController : Controller
    {
        private readonly INoSqlStorage<Vehicle> _vehicleStorage;

        public TableStoragesController(INoSqlStorage<Vehicle> vehicleStorage)
        {
            _vehicleStorage = vehicleStorage;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Vehicles = _vehicleStorage.GetAll().ToList();
            return View();
        }
    }
}
