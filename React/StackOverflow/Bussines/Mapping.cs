using AutoMapper;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines
{
  public class Mapping: Profile
  {
    public Mapping()
    {
      CreateMap<Question, QuestionViewModel>().ReverseMap();
      CreateMap<Answer, AnswerViewModel>().ReverseMap();

    }
  }
}
