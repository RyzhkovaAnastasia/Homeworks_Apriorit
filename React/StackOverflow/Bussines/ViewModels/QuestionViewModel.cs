using System;
using System.Collections.Generic;

namespace Bussines
{
  public class QuestionViewModel
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime CreationDateTime { get; set; }
    public string Description { get; set; }
    public int ViewNumber { get; set; }
    public int AnswerNumber { get; set; }
    public List<AnswerViewModel> Answers { get; set; }

    public QuestionViewModel()
    {
      Answers = new List<AnswerViewModel>();
    }
  }
}
