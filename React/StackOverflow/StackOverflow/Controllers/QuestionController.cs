using Bussines;
using Bussines.Domains.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace React.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class QuestionController : ControllerBase
  {
    private readonly IQuestionDomain _qDomain;

    public QuestionController(IQuestionDomain qDomain)
    {
      _qDomain = qDomain;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(_qDomain.GetQuestions());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      return Ok(_qDomain.GetQuestion(id));
    }

    [HttpPost]
    public IActionResult Post(QuestionViewModel question)
    {
      _qDomain.SetQuestion(question);
      return Ok();
    }

    [HttpPost("{id}")]
    public IActionResult IncrementViews(int id)
    {
      _qDomain.IncViews(id);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(QuestionViewModel question)
    {
      _qDomain.UpdateQuestion(question);
      return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      _qDomain.DeleteQuestion(id);
      return Ok();
    }
  }
}
