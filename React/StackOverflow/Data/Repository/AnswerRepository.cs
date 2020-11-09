using Data.Entities;
using Data.Repository.Interfaces;
using EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
  public class AnswerRepository: IAnswerRepository
  {
    private readonly IStackOverflowDBContext _context;

    public AnswerRepository(IStackOverflowDBContext context)
    {
      this._context = context;
    }
    public IEnumerable<Answer> GetAnswers(int questionId)
    {
      return _context.Answers.Where(answ => answ.QuestionId == questionId);
    }
    public void SetAnswer(Answer answer)
    {
      _context.Questions.Find(answer.QuestionId).AnswerNumber += 1;
      _context.Answers.Add(answer);
      _context.SaveChanges();
    }
    public void UpdateAnswer(Answer answer)
    {
      var oldAnswer = _context.Answers.Where(x => x.Id == answer.Id).FirstOrDefault();

      oldAnswer.AnswerText = answer.AnswerText;
      oldAnswer.QuestionId = answer.QuestionId;
      oldAnswer.Question = answer.Question;
      _context.SaveChanges();
    }
    public void DeleteAnswer(int answerId)
    {
      var answer = _context.Answers.Where(x => x.Id == answerId).FirstOrDefault();
      _context.Questions.Find(answer.QuestionId).AnswerNumber -= 1;
      _context.Answers.Remove(answer);
      _context.SaveChanges();
    }
  }
}
