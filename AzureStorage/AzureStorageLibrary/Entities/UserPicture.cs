namespace AzureStorageLibrary.Entities
{
    public class UserPicture : BaseTableEntity
    {
        public string RawPaths { get; set; }
        public string WatermarkRawPaths { get; set; }

        [JsonIgnore]
        public List<string> Paths
        {
            get
            {
                if (RawPaths is null)
                    return null;

                return JsonSerializer.Deserialize<List<string>>(RawPaths);
            }
            set
            {
                if (value is null)
                    return;

                RawPaths = JsonSerializer.Serialize(value);
            }
        }

        [JsonIgnore]
        public List<string> WatermarkPaths
        {
            get
            {
                if (WatermarkRawPaths is null)
                    return null;

                return JsonSerializer.Deserialize<List<string>>(WatermarkRawPaths);
            }
            set
            {
                if (value is null)
                    return;

                WatermarkRawPaths = JsonSerializer.Serialize(value);
            }
        }
    }
}
