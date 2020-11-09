using System.Collections.Generic;

namespace Bussines.Domains.Interfaces
{
  public interface IAnswerDomain
  {
    IEnumerable<AnswerViewModel> GetAnswers(int questionId);
    void SetAnswer(AnswerViewModel answer);
    void UpdateAnswer(AnswerViewModel answer);
    void DeleteAnswer(int answerId);
  }
}
