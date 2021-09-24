using Demos.AzureDevOps.Common.Entities;
using Demos.AzureDevOps.Common.Enums;
using Demos.AzureDevOps.Data.Mockups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Demos.AzureDevOps.Business.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetPeople_Success()
        {
            PeopleBll peopleBll = new PeopleBll();
            var peopleCount = peopleBll.GetPeople().Count();

            Assert.AreEqual(3, peopleCount);
        }

        [TestMethod]
        public void GetPeople_Fail()
        {
            PeopleBll peopleBll = new PeopleBll();
            var peopleCount = peopleBll.GetPeople().Count();

            Assert.AreNotEqual(0, peopleCount);
        }

        [TestMethod]
        public void GetPerson_Success()
        {
            int id = 1;

            PeopleBll peopleBll = new PeopleBll();
            var personActual = peopleBll.GetPerson(id);

            PeopleMock peopleMock = new PeopleMock();
            Person personExpected = peopleMock.People.FirstOrDefault(p => p.Id == id);

            Assert.AreEqual(personExpected.FirstName, personActual.FirstName);
            Assert.AreEqual(personExpected.LastName, personActual.LastName);
            Assert.AreEqual(personExpected.BirthDate, personActual.BirthDate);
            Assert.AreEqual(personExpected.Gender, personActual.Gender);
        }

        [TestMethod]
        public void DeletePerson_Success()
        {
            PeopleBll peopleBll = new PeopleBll();
            peopleBll.DeletePerson(2);
            var peopleCount = peopleBll.GetPeople().Count();

            Assert.AreEqual(2, peopleCount);
        }

        [TestMethod]
        public void TestMethod1()
        {
            PeopleBll peopleBll = new PeopleBll();

            Person personNew = new Person()
            {
                FirstName = "Jennifer",
                LastName = "Brown",
                BirthDate = new DateTime(2000, 1, 1),
                Gender = Gender.Female,
            };
            peopleBll.InsertPerson(personNew);

            var peopleCount = peopleBll.GetPeople().Count();
            Assert.AreEqual(4, peopleCount);

            Person personExpected = peopleBll.GetPeople().LastOrDefault();

            Assert.AreEqual(personExpected.FirstName, personNew.FirstName);
            Assert.AreEqual(personExpected.LastName, personNew.LastName);
            Assert.AreEqual(personExpected.BirthDate, personNew.BirthDate);
            Assert.AreEqual(personExpected.Gender, personNew.Gender);

        }
    }
}
