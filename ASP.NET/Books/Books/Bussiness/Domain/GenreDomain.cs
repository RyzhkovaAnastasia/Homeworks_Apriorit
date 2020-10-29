using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Books.Data.Models;
using Books.Data.Repository;
using Books.Bussiness.ViewModels;

namespace Book.Business.Domains
{
  public class GenreDomain
  {
    GenreRepository repository;
    IMapper mapper;

    public GenreDomain(IConfiguration configuration)
    {
      this.repository = new GenreRepository(configuration);
      this.mapper = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Genre, GenreViewModel>();
        cfg.CreateMap<Books.Data.Models.Book, BookViewModel>();
      }).CreateMapper();
    }

    public IEnumerable<GenreViewModel> Get()
    {
      var genres = repository.Get();
      return genres.Select(genre => mapper.Map<Genre, GenreViewModel>(genre));
    }
  }
}