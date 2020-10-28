using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using web_basics.business.ViewModels;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        business.Domains.Dog domain;

        public DogController(IConfiguration configuration) 
        {
            this.domain = new business.Domains.Dog(configuration);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dogs = this.domain.Get();
            return Ok(dogs);
        }

        [HttpPost]
        //[Route("addDog")]
        public ActionResult<Dog> Post(Dog dog)
        {
            if (dog != null)
            {
                domain.Post(dog);
                return Ok(JsonConvert.SerializeObject($"{dog.Name} was added to list"));
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
