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
    public IActionResult GetGenres()
    {
      var genres = genreDomain.Get();
      return Ok(genres);
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
      var books = bookDomain.Get();
      return Ok(books);
    }

    [HttpGet("book")]
    public IActionResult GetBook(int id)
    {
      var book = bookDomain.Get(id);
      return Ok(book);
    }

    [HttpGet("booksbygenre")]
    public IActionResult GetBooksByGenres(int id)
    {
      var books = bookDomain.GetByGenre(id);
      return Ok(books);
    }

    [HttpDelete]
    public IActionResult DeleteBook([FromQuery] int id)
    {
      bookDomain.Delete(id);
      return Ok();
    }

    [HttpPost]
    public IActionResult PostBook(BookViewModel book)
    {
      bookDomain.Post(book);
      return Ok();
    }

    [HttpPut]
    public IActionResult PutBook(BookViewModel book)
    {
      bookDomain.Put(book);
      return Ok();
    }
  }
}
