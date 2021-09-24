using Demos.AzureDevOps.Business;
using Demos.AzureDevOps.Common.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.AzureDevOps.Service.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly PeopleBll _peopleBll;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
            _peopleBll = new PeopleBll(); ;
        }

        [HttpGet]
        public IActionResult GetAction()
        {
            IEnumerable<Person> people = _peopleBll.GetPeople();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {
            Person person = _peopleBll.GetPerson(id);
            if (person == null)
                return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult PostAction(Person person)
        {
            Person result = null;
            if (person.Id > 0)
                result = _peopleBll.UpdatePerson(person);
            else
                result = _peopleBll.InsertPerson(person);

            if (result == null)
                return NotFound(person);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAction(int id)
        {
            _peopleBll.DeletePerson(id);

            return Ok();
        }
    }
}
