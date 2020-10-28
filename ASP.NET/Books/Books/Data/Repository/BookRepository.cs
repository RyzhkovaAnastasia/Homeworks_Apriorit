using Books.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data.Repository
{
  public class BookRepository
  {
    BooksDBContext context;

    public BookRepository(IConfiguration configuration)
    {
      this.context = new BooksDBContext(configuration);
    }

    public IEnumerable<Models.Book> Get()
    {
      var books = context.Books.ToList();
      return books;
    }

    public Models.Book Get(int id)
    {
      var book = context.Books.Where(book => book.Id == id).FirstOrDefault();
      if (book != null)
      {
        return book;
      }
      else
      {
        return null;
      }
    }

    public IEnumerable<Models.Book> GetByGenre(int idGenre)
    {
      var books = context.Books.Where(book => book.Genres.Contains(book.Genres.Where(genre => genre.Id == idGenre).FirstOrDefault()));
      if (books != null)
      {
        return books;
      }
      else
      {
        return null;
      }
    }

    public void Put(Models.Book book)
    {
      var oldBook = context.Books.Where(oldBook => oldBook.Id == book.Id).FirstOrDefault();
      if (oldBook != null)
        {
          oldBook.Title = book.Title;
          oldBook.Year = book.Year;
          oldBook.Author = book.Author;
          oldBook.Genres = book.Genres;
          oldBook.PublishingHouse = book.PublishingHouse;
          context.SaveChanges();
        }
    }

    public void Post(Models.Book book)
    {
      context.Books.Add(book);
      context.SaveChanges();
    }

    public void Delete(int id)
    {
      var book = context.Books.Where(book => book.Id == id).FirstOrDefault();
      if (book != null)
      {
        context.Books.Add(book);
      }
    }
  }
}
