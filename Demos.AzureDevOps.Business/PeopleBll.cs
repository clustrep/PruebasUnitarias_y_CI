using Demos.AzureDevOps.Common.Entities;
using Demos.AzureDevOps.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.AzureDevOps.Business
{
    public class PeopleBll
    {
        private readonly PeopleRepository _peopleRepository;


        public PeopleBll()
        {
            _peopleRepository = new PeopleRepository();
        }

        public IEnumerable<Person> GetPeople()
        {
            return _peopleRepository.SelectAll();
        }

        public Person GetPerson(int id)
        {
            return _peopleRepository.SelectById(id);
        }

        public Person UpdatePerson(Person person)
        {
            var result = _peopleRepository.Update(person);
            return result;
        }

        public Person InsertPerson(Person person)
        {
            var result = _peopleRepository.Insert(person);
            return result;
        }

        public void DeletePerson(int id)
        {
            _peopleRepository.Delete(id);
        }
    }
}
