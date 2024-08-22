using Joss.co.Common.Data.Interface;
using MongoDB.Bson.Serialization.Attributes;

namespace Joss.co.Data.Entites
{
  public class Products : IMongo
  {
    [BsonId]
    public Guid Id { get; set; }
    public string Name { get; set; }
  }
}