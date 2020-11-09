using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
  public class Answer
  {
    public int Id { get; set; }
    [Required]
    public string AnswerText { get; set; }
    [Required]
    public Question Question { get; set; }
    [Required]
    public int QuestionId { get; set; }
  }
}
