using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using NationalLoanServicing.Controllers;
using NationalLoanServicing.Domain.Model;
using NationalLoanServicing.Domain.Services;
using NationalLoanServicing.Models;
using Rhino.Mocks;

namespace Specs.ViewingLoans
{
    public class when_a_servicing_agent_is_viewing_loans : with_a_set_of_loans_and_a_servicing_agent
    {
        Because of = () => controller.List();

        It shows_all_the_loans = () =>
            view_model.Loans.Count.ShouldEqual(loans.Count);

        It shows_the_obligee_of_each_loan = () =>
            view_model.Loans.Each((x, i) => x.ObligeeName.ShouldEqual(loans[i].Obligee.FullName));

        It shows_the_loan_number_of_each_loan = () =>
            view_model.Loans.Each((x, i) => x.LoanNumber.ShouldEqual(loans[i].LoanNumber));
    }

    public abstract class with_a_set_of_loans_and_a_servicing_agent
    {
        protected static IList<Loan> loans;
        protected static ServicingAgent agent;
        static ILoanService loanService;

        Establish context = () => {
            loans = new List<Loan> { 
                new Loan { Obligee = new Person { GivenName = "Joe", Surname = "King" } },
                new Loan { Obligee = new Person { GivenName = "George", Surname = "Washington" } },
                new Loan { Obligee = new Person { GivenName = "Tom", Surname = "Payne" } }
            };
            agent = new ServicingAgent();

            loanService = MockRepository.GenerateStub<ILoanService>();

            loanService.Stub(x => x.GetLoans()).Return(loans);

            controller = new LoansController(loanService);
        };

        protected static LoansController controller;
        protected static LoansListViewModel view_model
        {
            get
            {
                return controller.ViewData["view_model"] as LoansListViewModel;
            }
        }
    }
}
