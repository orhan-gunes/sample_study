using SampleStudy.Domain.Dto;
using SampleStudy.Domain.Interfaces;
using SampleStudy.Infrastructure;

namespace SampleStudy.Application
{
    public class PersonService : IPersonService
    {
        private readonly IDataContextHelper _ctx;
        public PersonService(IDataContextHelper ctx)
        {
           _ctx = ctx;
        }

        public async Task<int> addPerson(PersonDto person)
        {
          return await _ctx.AddPersons(person);
        
        }

        public Task<int> deletePerson(long id)
        {
            return _ctx.DeletePerson(id);
        }

        public async Task<List<PersonDto>> getAllPersons()
        {


          return await  _ctx.GetAllPersons();
           
        }
        public Task<PersonDto> getPersonById(long id)
        {
            return _ctx.GetPersonById(id);
        }

        public Task<int> updatePerson(PersonDto person)
        {
           return _ctx.EditPersons(person);
        }
    }
}
