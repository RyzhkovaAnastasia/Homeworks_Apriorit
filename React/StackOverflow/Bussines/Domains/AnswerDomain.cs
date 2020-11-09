using Bussines.Domains.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using Data.Repository.Interfaces;
using Data.Entities;

namespace Bussines
{
  public class AnswerDomain: IAnswerDomain
  {
    private readonly IAnswerRepository _answRepository;
    private readonly IMapper _mapper;
    public AnswerDomain(IAnswerRepository answRepository, IMapper mapper)
    {
      _mapper = mapper;
      _answRepository = answRepository;
    }
    public IEnumerable<AnswerViewModel> GetAnswers(int questionId)
    {
      return _mapper.Map<IEnumerable<Answer>, IEnumerable<AnswerViewModel>>(_answRepository.GetAnswers(questionId));
    }
    public void SetAnswer(AnswerViewModel answer)
    {
      _answRepository.SetAnswer(_mapper.Map<AnswerViewModel, Answer>(answer));
    }
    public void UpdateAnswer(AnswerViewModel answer)
    {
      _answRepository.UpdateAnswer(_mapper.Map<AnswerViewModel, Answer>(answer));
    }
    public void DeleteAnswer(int answerId)
    {
      _answRepository.DeleteAnswer(answerId);
    }
  }
}
