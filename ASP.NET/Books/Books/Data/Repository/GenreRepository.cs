using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Books.Data.Repository
{
  public class GenreRepository
  {
    BooksDBContext context;

    public GenreRepository(IConfiguration configuration)
    {
      this.context = new BooksDBContext(configuration);
    }

    public IEnumerable<Models.Genre> Get()
    {
      var genres = context.Genres.ToList();
      return genres;
    }
  }
}
