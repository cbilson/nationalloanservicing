using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using NationalLoanServicing.Domain.Model;
using NationalLoanServicing.Domain.Services;

namespace NationalLoanServicing.Controllers
{
    public class PeopleController : Controller
    {
        private IPeopleService peopleService;

        /// <summary>
        /// Initializes a new instance of the PeopleController class.
        /// </summary>
        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
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

    public class PeopleListModel
    {
        public IList<Person> people { get; set; }
    }
}
