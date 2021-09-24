using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demos.AzureDevOps.Common.Entities;
using Demos.AzureDevOps.Common.Enums;

namespace Demos.AzureDevOps.Data.Mockups
{
    public class PeopleMock
    {
        public IList<Person> People = new List<Person>()
            {
                new Person() { Id = 1, FirstName = "Jamie", LastName = "Smith", BirthDate = new DateTime(1977, 3, 10), Gender = Gender.Male },
                new Person() { Id = 2, FirstName = "Jane", LastName = "Doe", BirthDate = new DateTime(1980, 2, 1), Gender = Gender.Female },
                new Person() { Id = 3, FirstName = "Greg", LastName = "Thomas", BirthDate = new DateTime(2006, 4, 30), Gender = Gender.Male },
            };
    }
}
