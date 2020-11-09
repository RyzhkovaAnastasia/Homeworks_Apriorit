using System.Collections.Generic;

namespace Bussines.Domains.Interfaces
{
  public interface IQuestionDomain
  {
    IEnumerable<QuestionViewModel> GetQuestions();
    QuestionViewModel GetQuestion(int id);
    void SetQuestion(QuestionViewModel question);
    void UpdateQuestion(QuestionViewModel question);
    void DeleteQuestion(int questionId);
    void IncViews(int id);
  }
}