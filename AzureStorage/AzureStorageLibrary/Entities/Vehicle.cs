namespace AzureStorageLibrary.Entities
{
    public class Vehicle : BaseTableEntity
    {
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string SubModelName { get; set; }
        public int ModelYear { get; set; }
    }
}
