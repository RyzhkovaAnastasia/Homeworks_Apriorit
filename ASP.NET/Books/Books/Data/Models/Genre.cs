﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Data.Models
{
  public class Genre
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Book> Books { get; set; }
    public Genre()
    {
      Books = new List<Book>();
    }
  }
}
