using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interfaces
{
  public interface IQuestionRepository
  {
    IEnumerable<Question> GetQuestions();
    Question GetQuestion(int id);
    void SetQuestion(Question question);
    void UpdateQuestion(Question question);
    void DeleteQuestion(int questionId);
    void IncViews(int id);
  }
}
