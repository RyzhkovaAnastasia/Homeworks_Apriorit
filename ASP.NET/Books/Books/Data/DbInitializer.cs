using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
  public static class DbInitializer
  {
    public static void Initialize(BooksDBContext context)
    {
      if (!context.Database.Exists())
      {
        if (!context.Books.Any() && !context.Genres.Any())
        {
          Models.Book book1 = new Models.Book { Title = "Фантастические истории игрушек", Author = "Кольс А.М.", Year = 1994 };
          Models.Book book2 = new Models.Book { Title = "Широкая улыбка моряка", Author = "Параходов О.В.", Year = 1990 };
          Models.Book book3 = new Models.Book { Title = "Приключения Шерлока Холмса", Author = "Конан-Дойль мл.", Year = 2001 };
          context.Books.AddRange(new List<Models.Book> { book1, book2, book3 });
          context.SaveChanges();

          Models.Genre genre1 = new Models.Genre { Name = "Приключения" };
          genre1.Books.Add(book2);
          genre1.Books.Add(book3);
          Models.Genre genre2 = new Models.Genre { Name = "Фантастика" };
          genre2.Books.Add(book1);
          context.Genres.Add(genre1);
          context.Genres.Add(genre2);
          context.SaveChanges();
        }
      }
    }
  }
}
