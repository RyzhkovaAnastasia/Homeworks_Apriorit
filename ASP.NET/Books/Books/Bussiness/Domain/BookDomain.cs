using AutoMapper;
using Books.Bussiness.ViewModels;
using Books.Data.Models;
using Books.Data.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Bussiness.Domain
{
  public class BookDomain
  {
    BookRepository repository;
    IMapper mapper;

    public BookDomain(IConfiguration configuration)
    {
      this.repository = new BookRepository(configuration);
    }

    public IEnumerable<BookViewModel> Get()
    {
      mapper = new MapperConfiguration(cfg => {
        cfg.CreateMap<Data.Models.Book, BookViewModel>();
        cfg.CreateMap<Data.Models.Genre, GenreViewModel>();
      }).CreateMapper();
      var books = repository.Get();
      return books.Select(book => mapper.Map<Data.Models.Book, BookViewModel>(book));
    }

    public BookViewModel Get(int id)
    {
      mapper = new MapperConfiguration(cfg => {
        cfg.CreateMap<Data.Models.Book, BookViewModel>();
        cfg.CreateMap<Data.Models.Genre, GenreViewModel>();
      }).CreateMapper();
      var book = repository.Get(id);
      return mapper.Map<Data.Models.Book, BookViewModel>(book);
    }

    public IEnumerable<BookViewModel> GetByGenre(int idGenre)
    {
      mapper = new MapperConfiguration(cfg => {
        cfg.CreateMap<Data.Models.Book, BookViewModel>();
        cfg.CreateMap<Data.Models.Genre, GenreViewModel>();
      }).CreateMapper();
      var books = repository.GetByGenre(idGenre);
      return books.Select(book => mapper.Map<Data.Models.Book, BookViewModel>(book));
    }

    public void Put(BookViewModel book)
    {
      this.mapper = new MapperConfiguration(cfg => {
        cfg.CreateMap<BookViewModel, Data.Models.Book>();
        cfg.CreateMap<GenreViewModel, Data.Models.Genre>();
      }).CreateMapper();
      var newBook = mapper.Map< BookViewModel, Data.Models.Book>(book);
      repository.Put(newBook);
    }

    public void Post(BookViewModel book)
    {
      this.mapper = new MapperConfiguration(cfg => {
        cfg.CreateMap<BookViewModel, Data.Models.Book>();
        cfg.CreateMap<GenreViewModel, Data.Models.Genre>();
      }).CreateMapper();
      var newBook = mapper.Map<BookViewModel, Data.Models.Book>(book);

      repository.Post(newBook);
    }
    public void Delete(int id)
    {
      repository.Delete(id);
    }
  }
}
