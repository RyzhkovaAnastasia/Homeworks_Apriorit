using Data.Repository;
using MongoDB.Driver;

namespace NoSQL
{
  class Program
  {
    static void Main(string[] args)
    {
      string connectionString = "mongodb://localhost:27017";
      MongoClient client = new MongoClient(connectionString);
      IMongoDatabase database = client.GetDatabase("vetclinicdb");

      var petRep = new PetRepository(database);
      petRep.InitializePetCollection();

      petRep.PrintSelectedPage(3);
      petRep.GererateReport();
    }
  }
}
