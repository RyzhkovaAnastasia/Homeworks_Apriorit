using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Bussiness.ViewModels
{
  public class GenreViewModel
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<BookViewModel> Books { get; set; }
  }
}
