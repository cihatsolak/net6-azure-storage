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

        [HttpGet]
        public async Task<IActionResult> Update(string rowKey, string partitionKey)
        {
            ViewBag.IsUpdate = true;
            ViewBag.Vehicles = _vehicleStorage.GetAll().ToList();
            var vehicle = await _vehicleStorage.GetByRowAndPartitionKeyAsync(rowKey, partitionKey);

            return View("Index", vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Vehicle vehicle)
        {
            await _vehicleStorage.UpdateAsync(vehicle);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string rowKey, string partitionKey)
        {
            await _vehicleStorage.DeleteByRowAndPartitionKeyAsync(rowKey, partitionKey);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Query(string searchModelName)
        {
            ViewBag.Vehicles = _vehicleStorage.Query(p => p.ModelName.Equals(searchModelName)).ToList();

            return View("Index");
        }
    }
}
