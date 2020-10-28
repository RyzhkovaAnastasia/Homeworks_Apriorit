using Books.Data.Models;
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
      context.Database.EnsureCreated();

      Book book1 = new Book { Title = "Фантастические истории игрушек", Author = "Кольс А.М.", Year = 1994 };
      Book book2 = new Book { Title = "Широкая улыбка моряка", Author = "Параходов О.В.", Year = 1990 };
      Book book3 = new Book { Title = "Приключения Шерлока Холмса", Author = "Конан-Дойль мл.", Year = 2001 };
      context.Books.AddRange(new List<Book> { book1, book2, book3 });
      context.SaveChanges();

      Genre genre1 = new Genre { Name = "Приключения" };
      genre1.Books.Add(book2);
      genre1.Books.Add(book3);
      Genre genre2 = new Genre { Name = "Фантастика" };
      genre2.Books.Add(book1);
      context.Genres.Add(genre1);
      context.Genres.Add(genre2);
      context.SaveChanges();
    }
  }
}
