using MongoDB.Bson;

namespace Data.Models
{
  public class Owner
  {
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
  }
}
