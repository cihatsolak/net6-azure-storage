namespace AzureStorageLibrary.Infrastructure
{
    /// <summary>
    /// Table Storage (NoSql)
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface INoSqlStorage<TEntity> where TEntity : class, ITableEntity, new()
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByRowAndPartitionKeyAsync(string rowKey, string partitionKey);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteByRowAndPartitionKeyAsync(string rowKey, string partitionKey);
    }
}
