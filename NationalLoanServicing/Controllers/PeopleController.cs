using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NationalLoanServicing.Domain.Model;

namespace NationalLoanServicing.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService peopleService;

        /// <summary>
        /// Initializes a new instance of the PeopleController class.
        /// </summary>
        public PeopleController()
        {
            peopleService = new PeopleService();
        }

        public ActionResult Index()
        {
            var people = peopleService.GetAllPeople();
            return View(new PeopleListModel { people = people });
        }

        public ActionResult New(string givenName, string surname)
        {
            peopleService.Save(new Person { GivenName = givenName,
                                            Surname = surname
            });

            return View("Index", new PeopleListModel { 
                people = peopleService.GetAllPeople() });
        }

    }

    public interface IPeopleService
    {
        IList<Person> GetAllPeople();
        void Save(Person person);
    }

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

    public class PeopleListModel
    {
        public IList<Person> people { get; set; }
    }
}
