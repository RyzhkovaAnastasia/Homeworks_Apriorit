using Data.Models;
using Enums;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
  public class PetRepository : Repository<Pet>
  {
    public PetRepository(IMongoDatabase database) : base(database)
    {
      _collection.Indexes.CreateOne(new CreateIndexModel<Pet>("{ RegistrationDate: 1 }"));
    }

    public void InitializePetCollection()
    {
      if (_collection.EstimatedDocumentCount() == 0)
      {
        List<Pet> pets = new List<Pet>()
        {
          new Pet
          {
            Name = "Iggy",
            AnimalType = AnimalType.Dog,
            RegistrationDate = DateTime.Now.AddMinutes(-78),
            Owner = new Owner
            {
              Name = "Jotaro Kujo",
              PhoneNumber = "+380971111111"
            }
          },
          new Pet
          {
            Name = "Hedwig",
            AnimalType = AnimalType.Bird,
            RegistrationDate = DateTime.Now.AddMinutes(-32),
            Owner = new Owner
            {
              Name = "Harry Potter",
              PhoneNumber = "+380972222222"
            }
          },
          new Pet
          {
            Name = "Einstein",
            AnimalType = AnimalType.Dog,
            RegistrationDate = DateTime.Now.AddMinutes(-98),
            Owner = new Owner
            {
              Name = "Marty McFly",
              PhoneNumber = "+380973333333"
            }
          },
          new Pet
          {
            Name = "Pit Bull",
            AnimalType = AnimalType.Dog,
            RegistrationDate = DateTime.Now.AddMinutes(-73),
            Owner = new Owner
            {
              Name = "John Wick",
              PhoneNumber = "+380974444444"
            }
          },
          new Pet
          {
            Name = "Samantha",
            AnimalType = AnimalType.Dog,
            RegistrationDate = DateTime.Now.AddMinutes(-134),
            Owner = new Owner
            {
              Name = "Robert Neville",
              PhoneNumber = "+380975555555"
            }
          },
          new Pet
          {
            Name = "Scooby-Doo",
            AnimalType = AnimalType.Dog,
            RegistrationDate = DateTime.Now.AddMinutes(-132),
            Owner = new Owner
            {
              Name = "Shaggy",
              PhoneNumber = "+380976666666"
            }
          },
          new Pet
          {
            Name = "Bruiser",
            AnimalType = AnimalType.Dog,
            RegistrationDate = DateTime.Now.AddMinutes(-34),
            Owner = new Owner
            {
              Name = "Elle Woods",
              PhoneNumber = "+380977777777"
            }
          },
          new Pet
          {
            Name = "Milo",
            AnimalType = AnimalType.Dog,
            RegistrationDate = DateTime.Now.AddMinutes(-90),
            Owner = new Owner
            {
              Name = "Stanley Ipkiss",
              PhoneNumber = "+38098888888"
            }
          },
          new Pet
          {
            Name = "Mrs. Norris",
            AnimalType = AnimalType.Cat,
            RegistrationDate = DateTime.Now.AddMinutes(-12),
            Owner = new Owner
            {
              Name = "Argus Filch",
              PhoneNumber = "+38099999999"
            }
          },
          new Pet
          {
            Name = "Crookshanks",
            AnimalType = AnimalType.Cat,
            RegistrationDate = DateTime.Now.AddMinutes(-13),
            Owner = new Owner
            {
              Name = "Hermione Granger",
              PhoneNumber = "+380101010010"
            }
          },
          new Pet
          {
            Name = "Garfield",
            AnimalType = AnimalType.Cat,
            RegistrationDate = DateTime.Now.AddMinutes(-40),
            Owner = new Owner
            {
              Name = "Jon Arbuckle",
              PhoneNumber = "+380110111111"
            }
          },
          new Pet
          {
            Name = "Garfield",
            AnimalType = AnimalType.Cat,
            RegistrationDate = DateTime.Now.AddMinutes(-10),
            Owner = new Owner
            {
              Name = "Jon Arbuckle",
              PhoneNumber = "+380110111111"
            }
          },
          new Pet
          {
            Name = "Bloodwing",
            AnimalType = AnimalType.Bird,
            RegistrationDate = DateTime.Now.AddMinutes(-200),
            Owner = new Owner
            {
              Name = "Mordecai",
              PhoneNumber = "+38097121212"
            }
          },
          new Pet
          {
            Name = "Buckbeak",
            AnimalType = AnimalType.Bird,
            RegistrationDate = DateTime.Now.AddMinutes(-560),
            Owner = new Owner
            {
              Name = "Rubeus Hagrid",
              PhoneNumber = "+38097323232"
            }
          }
        };
        _collection.InsertMany(pets);
      }
    }
    public void PrintSelectedPage(int showOnPage)
    {
      var pageCount = Math.Ceiling(_collection.EstimatedDocumentCount() / showOnPage * 1.0);
      var nav = ConsoleKey.Enter;
      int page = 1;

      while (nav != ConsoleKey.Escape) {
        switch (nav)
        {
          case ConsoleKey.RightArrow:
            page = page < pageCount ? page + 1 : page;
            break;
          case ConsoleKey.D:
            page = page < pageCount ? page + 1 : page;
            break;
          case ConsoleKey.LeftArrow:
            page = page > 1 ? page - 1 : page;
            break;
          case ConsoleKey.A:
            page = page > 1 ? page - 1 : page;
            break;
          default:
            break;
        }

        PrintPage(page, showOnPage);

        Console.WriteLine($"Page { page } of {pageCount}");
        Console.WriteLine("Press arrows or 'A' and 'D' to navigate pages. Press ESC for exit");
        nav = Console.ReadKey().Key;
        Console.Clear();
      }
    }

    private void PrintPage(int page, int showOnPage)
    {
      List<Pet> petsOnPage =
          _collection
          .Find(_ => true)
          .SortByDescending(p => p.RegistrationDate)
          .Skip(page * showOnPage)
          .Limit(showOnPage)
          .ToList();

      foreach (var pet in petsOnPage)
      {
        PrintPet(pet);
      }
    }

    private void PrintPet(Pet pet)
    {
      Console.WriteLine($"Pet name: {pet.Name}");
      Console.WriteLine($"Animal: {pet.AnimalType}");
      Console.WriteLine($"Registration date: {pet.RegistrationDate}");
      Console.WriteLine($"Owner name: {pet.Owner.Name}");
      Console.WriteLine($"Owner phone: {pet.Owner.PhoneNumber}");
      Console.WriteLine("\n");
    }

    public void GererateReport()
    {
      var groupByType = _collection
        .Aggregate()
        .Group(pet => pet.AnimalType, group => new { Type = group.Key, Count = group.Count() })
        .SortByDescending(g => g.Count)
        .ToList();

      Console.WriteLine("Report: count animals by type");
      foreach (var pet in groupByType)
        Console.WriteLine($"{pet.Type} - {pet.Count}");
    }
  }
}
