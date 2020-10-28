using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private business.Domains.Account domain;
        public AdminController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Account(configuration);

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var accounts = this.domain.Get().Where(user => user.Role == Role.User);
            return Ok(accounts);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(business.ViewModels.Account account)
        {
            domain.Post(account);
            return Ok(JsonConvert.SerializeObject("Account was successfully added"));
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(business.ViewModels.Account account)
        {
            domain.Put(account);
            return Ok(JsonConvert.SerializeObject("Account was successfully updated"));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromRoute]int id)
        {
            domain.Delete(id);
            return Ok(JsonConvert.SerializeObject("Account was successfully deleted"));
        }
    }
}
