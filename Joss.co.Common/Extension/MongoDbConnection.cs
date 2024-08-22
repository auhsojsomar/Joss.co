using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Joss.co.Common.Data.Interface;
using Joss.co.Common.Services;
using Joss.co.Common.Settings;
using MongoDB.Driver;

namespace Joss.co.Common.Extension
{
  public static class MongoDbConnection
  {
    public static IServiceCollection AddMongoDbConnection(this IServiceCollection services)
    {

      services.AddSingleton(serviceProvider =>
      {
        var configuration = serviceProvider.GetService<IConfiguration>();
        var mongoSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();

        string connectionString = mongoSettings.ConnectionString;
        string databaseName = mongoSettings.DatabaseName;

        MongoClient mongoClient = new MongoClient(connectionString);
        IMongoDatabase mongoDatabase = mongoClient.GetDatabase(databaseName);

        return mongoDatabase;
      });

      return services;
    }

    public static IServiceCollection AddMongoDbCollections<T>(this IServiceCollection services, string collectionName) where T : IMongo
    {
      services.AddSingleton<IMongoDbService<T>>(serviceProvider =>
      {
        var database = serviceProvider.GetService<IMongoDatabase>();
        return new MongoDbService<T>(database, collectionName);
      });

      return services;
    }
  }
}