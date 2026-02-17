using SampleStudy.Domain.Dto;

namespace SampleStudy.Domain.Interfaces
{
    public interface IPersonService
    {
         Task<List<PersonDto>> getAllPersons();
         Task<PersonDto> getPersonById(long id);
         Task<int> addPerson(PersonDto person);
         Task<int> updatePerson(PersonDto person);
         Task<int> deletePerson(long id);
    }
}
