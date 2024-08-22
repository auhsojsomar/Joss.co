using Joss.co.Common.Data.Interface;

namespace Joss.co.Common.Services
{
  public interface IMongoDbService<T> where T : IMongo
  {
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T?> GetAsync(Guid id);
    public Task<T> CreateAsync(T entity);
  }
}