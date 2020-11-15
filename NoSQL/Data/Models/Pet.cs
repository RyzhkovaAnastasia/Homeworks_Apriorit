using Enums;
using MongoDB.Bson;
using System;

namespace Data.Models
{
  public class Pet
  {
    public ObjectId Id { get; set; }
    public string Name { get; set; }
    public AnimalType AnimalType { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Owner Owner { get; set; }
  }
}
