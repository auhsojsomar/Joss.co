using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Joss.co.Common.Data.Interface
{
  public interface IMongo
  {
    public Guid Id { get; set; }
  }
}