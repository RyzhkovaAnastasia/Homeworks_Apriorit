using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data
{
  public class Question
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public DateTime CreationDateTime { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int ViewNumber { get; set; }
    public int AnswerNumber { get; set; }
    public List<Answer> Answers { get; set; }

    public Question()
    {
      Answers = new List<Answer>();
    }
  }
}
