using Data.Entities;
using Data.Repository.Interfaces;
using EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
  public class QuestionRepository: IQuestionRepository
  {
    private readonly IStackOverflowDBContext _context;

    public QuestionRepository(IStackOverflowDBContext context)
    {
      this._context = context;
    }
    public IEnumerable<Question> GetQuestions()
    {
      return _context.Questions.ToList();
    }

    public Question GetQuestion(int id)
    {
      return _context.Questions.Where(x => x.Id == id).FirstOrDefault();
    }
    public void SetQuestion(Question question)
    {
      _context.Questions.Add(question);
      _context.SaveChanges();
    }
    public void IncViews(int id)
    {
      var oldQuestion = _context.Questions.Where(x => x.Id == id).FirstOrDefault();

      oldQuestion.ViewNumber += 1;
      _context.SaveChanges();
    }
    public void UpdateQuestion(Question question)
    {
      var oldQuestion = _context.Questions.Where(x => x.Id == question.Id).FirstOrDefault();

      oldQuestion.ViewNumber = question.ViewNumber;
      oldQuestion.Title = question.Title;
      oldQuestion.Description = question.Description;
      oldQuestion.CreationDateTime = question.CreationDateTime;
      oldQuestion.Author = question.Author;
      oldQuestion.Answers = question.Answers;
      _context.SaveChanges();
    }
    public void DeleteQuestion(int questionId)
    {
      var question = _context.Questions.Where(x => x.Id == questionId).FirstOrDefault();
      _context.Questions.Remove(question);
    }
  }
}
