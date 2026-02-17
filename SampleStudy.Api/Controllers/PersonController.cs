using Microsoft.AspNetCore.Mvc;
using SampleStudy.Domain.Dto;
using SampleStudy.Domain.Interfaces;

namespace SampleStudy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController:ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("GetPersonAll")]
        public async Task<IActionResult> GetPersonAll()
        {
            
            return await  _personService.getAllPersons().ContinueWith<IActionResult>(t =>
            {
                if (t.IsFaulted)
                {
                    return BadRequest(t.Exception);
                }
                return Ok(t.Result);
            });
        }

        [HttpGet]
        [Route("GetPersonById")]
        public Task<IActionResult> GetPersonById(long Id)
        {
            return _personService.getPersonById(Id).ContinueWith<IActionResult>(t =>
            {
                if (t.IsFaulted)
                {
                    return BadRequest(t.Exception);
                }
                return Ok(t.Result);
            });
        }

        [HttpPut]
        [Route("AddPerson")]
        public Task<IActionResult> AddPerson(PersonDto item)
        {
            return _personService.addPerson(item).ContinueWith<IActionResult>(t =>
            {
                if (t.IsFaulted)
                {
                    return BadRequest(t.Exception);
                }
                return Ok(t.Result);
            });
        }


        [HttpPost]
        [Route("EditPerson")]
        public Task<IActionResult> EditPerson(PersonDto item)
        {
            return _personService.updatePerson(item).ContinueWith<IActionResult>(t =>
            {
                if (t.IsFaulted)
                {
                    return BadRequest(t.Exception);
                }
                return Ok(t.Result);
            });
        }

        [HttpDelete]
        [Route("DeletePerson")]
        public Task<IActionResult> DeletePerson(long Id)
        {
            return _personService.deletePerson(Id).ContinueWith<IActionResult>(t =>
            {
                if (t.IsFaulted)
                {
                    return BadRequest(t.Exception);
                }
                return Ok(t.Result);
            });
        }


    }
}
