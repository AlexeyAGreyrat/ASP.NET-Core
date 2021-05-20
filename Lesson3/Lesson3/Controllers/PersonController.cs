using Lesson3.Domain.Interfaces;
using Lesson3.Models;
using Lesson3.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        //GET /persons/{id}
        [HttpGet("/persons/{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _personManager.GetItem(id);
            return Ok(result);
        }
        //GET /persons/search?searchName = { name }
        [HttpGet("/persons/search/{name}")]
        public IActionResult GetForName([FromRoute] string name)
        {
            var result = _personManager.GetItems(name);
            return Ok(result);
        }
        //GET /persons/?skip={5}&take={10} 
        [HttpGet("/persons")]
        public IActionResult GetSkip([FromQuery] int skip, [FromQuery] int take )
        {
            var result = _personManager.GetSkip(skip,take);
            return Ok(result);
        }

        //POST /persons
        [HttpPost("/persons")]
        public IActionResult Create([FromBody] PersonCreate person)
        {
            var id = _personManager.Create(person);
            return Ok(id);
        }
        //PUT /persons
        [HttpPut("/persons")]
        public IActionResult Update([FromBody] Person person)
        {
            _personManager.Update(person);
            return Ok("Update");
        }
        //DELETE /persons/{id}
        [HttpDelete("/persons/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _personManager.Delete(id);
            return Ok($"Delete user {id}");
        }
    }
}
