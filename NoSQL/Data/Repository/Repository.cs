using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
  public abstract class Repository<T>
  {
    protected IMongoCollection<T> _collection { get; set; }
    public Repository(IMongoDatabase database)
    {
      _collection = database.GetCollection<T>(typeof(T).Name);
    }
  }
}
