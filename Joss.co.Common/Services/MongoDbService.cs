using Joss.co.Common.Data.Interface;
using Joss.co.Common.Extension;
using Joss.co.Common.Settings;
using MongoDB.Driver;

namespace Joss.co.Common.Services
{
  public class MongoDbService<T> : IMongoDbService<T> where T : IMongo
  {
    private readonly IMongoCollection<T> _collection;

    public MongoDbService(IMongoDatabase database, string collectionName)
    {
      _collection = database.GetCollection<T>(collectionName);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _collection.Find(x => true).ToListAsync();
    }

    public async Task<T?> GetAsync(Guid id)
    {
      return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
      await _collection.InsertOneAsync(entity);

      return entity;
    }
  }
}