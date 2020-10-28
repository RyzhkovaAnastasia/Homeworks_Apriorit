using Books.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
  public class BooksDBContext : DbContext
  {
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    IConfiguration _configuration;

    public BooksDBContext(IConfiguration configuration) : base()
    {
      this._configuration = configuration;
      DbInitializer.Initialize(this);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }
  }
}
