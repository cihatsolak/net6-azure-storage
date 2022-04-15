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

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            vehicle.RowKey = Guid.NewGuid().ToString(); //Benzersiz değer atamak
            vehicle.PartitionKey = "Volkswagen"; //Gruplama yapmak

            await _vehicleStorage.AddAsync(vehicle);

            return RedirectToAction(nameof(Index));
        }
    }
}
