using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data
{
  public class BooksDBContext : DbContext
  {
    public DbSet<Models.Book> Books { get; set; }
    public DbSet<Models.Genre> Genres { get; set; }
    IConfiguration _configuration;

    public BooksDBContext(IConfiguration configuration) : base("DefaultConnection")
    {
      this._configuration = configuration;
      DbInitializer.Initialize(this);
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //  optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    //}
  }
}
