using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace web_basics.data
{
    public static class DbInitializer
    {
        public static void Initialize(WebBasicsDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Cats.Any())
            {
                context.Cats.AddRange(new Entities.Cat[] {
                new Entities.Cat() { Name = "Barsik", Age = 3 },
                new Entities.Cat() { Name = "Kozkii", Age = 4 },
                new Entities.Cat() { Name = "Murka", Age = 13 },
                new Entities.Cat() { Name = "Bony", Age = 2 }
            });
            }

            if (!context.Dogs.Any())
            {
                context.Dogs.AddRange(new Entities.Dog[] {
                new Entities.Dog() { Name = "Sharick", Age = 10 },
                new Entities.Dog() { Name = "Miya", Age = 2 },
                new Entities.Dog() { Name = "Robert", Age = 9 },
                new Entities.Dog() { Name = "Bonya", Age = 5 }
            });
            }

            context.SaveChanges();
        }
    }
}
