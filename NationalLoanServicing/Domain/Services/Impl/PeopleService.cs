using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalLoanServicing.Domain.Model;

namespace NationalLoanServicing.Domain.Services.Impl
{
    public class PeopleService : IPeopleService
    {
        private List<Person> people;

        /// <summary>
        /// Initializes a new instance of the PeopleService class.
        /// </summary>
        public PeopleService()
        {
            people = new List<Person> { 
                new Person { GivenName = "Joe", Surname = "King" }
            };
        }

        public IList<Person> GetAllPeople()
        {
            return people;
        }

        public void Save(Person person)
        {
            people.Add(person);
        }
    }
}
