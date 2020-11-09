using AutoMapper;
using Bussines.Domains.Interfaces;
using Data;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bussines.Domains
{
  public class QuestionDomain: IQuestionDomain
  {
    private readonly IQuestionRepository _questRepository;
    private readonly IMapper _mapper;
    public QuestionDomain(IQuestionRepository questRepository, IMapper mapper)
    {
      _mapper = mapper;
      _questRepository = questRepository;
    }
    public IEnumerable<QuestionViewModel> GetQuestions()
    {
       var q = _mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(_questRepository.GetQuestions());
      return q;
    }
    public QuestionViewModel GetQuestion(int id)
    {
      return _mapper.Map<Question, QuestionViewModel>(_questRepository.GetQuestion(id));
    }
    public void SetQuestion(QuestionViewModel question)
    {
      _questRepository.SetQuestion(_mapper.Map<QuestionViewModel, Question>(question));
    }
    public void IncViews(int id)
    {
      _questRepository.IncViews(id);
    }

    public void UpdateQuestion(QuestionViewModel question)
    {
      _questRepository.UpdateQuestion(_mapper.Map<QuestionViewModel, Question>(question));
    }
    public void DeleteQuestion(int questionId)
    {
      _questRepository.DeleteQuestion(questionId);
    }
  }
}
