namespace AzureStorageLibrary.Services
{
    public class TableStorage<TEntity> : INoSqlStorage<TEntity> where TEntity : class, ITableEntity, new()
    {
        private readonly TableServiceClient _tableServiceClient; //Tüm tablolar üzerinde işlem yapmak
        private readonly TableClient _tableClient; //Tek bir tablo üzerinde işlem yapmak

        public TableStorage()
        {
            _tableServiceClient = new TableServiceClient(ConnectionStrings.StorageConnectionString);
            _tableClient = new TableClient(ConnectionStrings.StorageConnectionString, typeof(TEntity).Name);

            _tableClient.CreateIfNotExists(); //class'a ait tablo yoksa oluştur.
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var response = await _tableClient.AddEntityAsync(entity);
            if (response.IsError)
                throw new Exception("The add operation failed.");

            return entity;
        }

        public async Task DeleteByRowAndPartitionKeyAsync(string rowKey, string partitionKey)
        {
            await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<TEntity> GetByRowAndPartitionKeyAsync(string rowKey, string partitionKey)
        {
            try
            {
                return await _tableClient.GetEntityAsync<TEntity>(partitionKey, rowKey);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TEntity> GetAll()
        {
            return _tableClient.Query<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression)
        {
            return _tableClient.Query<TEntity>().Where(expression.Compile()).AsQueryable();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var response = await _tableClient.UpdateEntityAsync(entity, ETag.All, TableUpdateMode.Merge);
            if (response.IsError)
                throw new Exception("update process failed.");

            return entity;
        }
    }
}
