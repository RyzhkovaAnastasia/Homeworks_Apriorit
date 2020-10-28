using Books.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Bussiness.ViewModels
{
  public class BookViewModel
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    public int Year { get; set; }
    public string PublishingHouse { get; set; }
    public List<GenreViewModel> Genres { get; set; }
  }
}
