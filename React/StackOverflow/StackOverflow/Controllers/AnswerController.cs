using Bussines;
using Bussines.Domains.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace React.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AnswerController : ControllerBase
  {
    private readonly IAnswerDomain _aDomain;

    public AnswerController(IAnswerDomain aDomain)
    {
      _aDomain = aDomain;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return Ok(_aDomain.GetAnswers(id));
    }

    [HttpPost]
    public IActionResult Post(AnswerViewModel answer)
    {
      _aDomain.SetAnswer(answer);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(AnswerViewModel answer)
    {
      _aDomain.UpdateAnswer(answer);
      return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      _aDomain.DeleteAnswer(id);
      return Ok();
    }
  }
}
