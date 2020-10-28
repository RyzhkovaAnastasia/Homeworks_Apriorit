using Book.Business.Domains;
using Books.Bussiness.Domain;
using Books.Bussiness.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class BookLibrary : ControllerBase
  {
    private BookDomain bookDomain;
    private GenreDomain genreDomain;

    public BookLibrary(IConfiguration configuration)
    {
      this.bookDomain = new BookDomain(configuration);
      this.genreDomain = new GenreDomain(configuration);

    }

    [HttpGet]
    [Route("genres")]
    public IEnumerable<GenreViewModel> GetGenres()
    {
      return genreDomain.Get();
    }

    [HttpGet]
    public IEnumerable<BookViewModel> GetBooks()
    {
      return bookDomain.Get();
    }

    [HttpGet("book")]
    public BookViewModel GetBook(int id)
    {
      return bookDomain.Get(id);
    }

    [HttpGet("booksbygenre")]
    public IEnumerable<BookViewModel> GetBooksByGenres(int id)
    {
      return bookDomain.GetByGenre(id);
    }

    [HttpDelete]
    public void DeleteBook(int id)
    {
      bookDomain.Delete(id);
    }

    [HttpPost]
    public void PostBook(BookViewModel book)
    {
      bookDomain.Put(book);
    }

    [HttpPut]
    public void PutBook(BookViewModel book)
    {
      bookDomain.Put(book);
    }
  }
}
