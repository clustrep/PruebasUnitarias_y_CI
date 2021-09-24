using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demos.AzureDevOps.Common.Entities;
using Demos.AzureDevOps.Data.Mockups;

namespace Demos.AzureDevOps.Data
{
    public class PeopleRepository
    {
        PeopleMock _peopleData;

        public PeopleRepository()
        {
            _peopleData = new PeopleMock();
        }

        public IEnumerable<Person> SelectAll()
        {
            return _peopleData.People;
        }

        public Person SelectById(int id)
        {
            return _peopleData.People.FirstOrDefault(p => p.Id == id);
        }

        public Person Insert(Person obj)
        {
            int id = _peopleData.People.OrderBy(p => p.Id).LastOrDefault().Id + 1;

            obj.Id = id;
            obj.CreatedBy = "Repository";
            obj.CreatedDate = DateTime.UtcNow;
            _peopleData.People.Add(obj);

            return obj;
        }

        public Person Update(Person obj)
        {
            Person person = _peopleData.People.FirstOrDefault(p => p.Id == obj.Id);

            if (person == null)
                return null;

            person.FirstName = obj.FirstName;
            person.LastName = obj.LastName;
            person.BirthDate = obj.BirthDate;
            person.Gender = obj.Gender;
            person.LastUpdatedBy = "Repository";
            person.LastUpdatedDate = DateTime.UtcNow;

            return person;
        }

        public void Delete(int id)
        {
            var person = SelectById(id);
            _peopleData.People.Remove(person);
        }

        public void Delete(Person obj)
        {
            _peopleData.People.Remove(obj);
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
