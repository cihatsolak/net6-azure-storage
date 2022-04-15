namespace AzureTableStorageWebApp.Controllers
{
    public class TableStoragesController : Controller
    {
        private readonly INoSqlStorage<Vehicle> _vehicleStorage;

        public TableStoragesController(INoSqlStorage<Vehicle> vehicleStorage)
        {
            _vehicleStorage = vehicleStorage;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
