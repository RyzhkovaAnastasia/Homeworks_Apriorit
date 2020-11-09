using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository.Interfaces
{
  public interface IAnswerRepository
  {
    IEnumerable<Answer> GetAnswers(int questionId);
    void SetAnswer(Answer answer);
    void UpdateAnswer(Answer answer);
    void DeleteAnswer(int answerId);
  }
}
