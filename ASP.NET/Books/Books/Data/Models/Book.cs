using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data.Models
{
  public class Book
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public int Year { get; set; }
    public string PublishingHouse { get; set; }
    public List<Genre> Genres { get; set; }
    public Book()
    {
      Genres = new List<Genre>();
    }

  }
}
