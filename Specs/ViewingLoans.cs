using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Rhino.Mocks;

namespace Specs.ViewingLoans
{
    public class when_a_servicing_agent_is_viewing_loans : with_a_set_of_loans_and_a_servicing_agent
    {
        Because of = () => 
            view_model = controller.List();

        It shows_all_the_loans = () =>
            view_model.Loans.Count.ShouldEqual(loans.Count);

        It shows_the_obligee_of_each_loan = () =>
            view_model.Loans[0].ObligeeName.ShouldEqual(loans[0].Obligee.FullName);

        private static LoansListViewModel view_model;
    }

    public class LoansListViewModel
    {
        public virtual IList<LoanInfo> Loans { get; set; }
    }

    public class LoanInfo
    {
        public virtual string ObligeeName { get; set; }
    }

    public class LoansController
    {
        private readonly ILoanService loanService;

        public LoansController(ILoanService loanService) {
            this.loanService = loanService;
        }

        public LoansListViewModel List()
        {
            var loans = loanService.GetLoans();

            return new LoansListViewModel {
                Loans = loans.Select(x => new LoanInfo {
                    ObligeeName = x.Obligee.FullName
                }).ToList()
            };
        }
    }

    public interface ILoanService
    {
        IList<Loan> GetLoans();
    }

    public abstract class with_a_set_of_loans_and_a_servicing_agent
    {
        protected static IList<Loan> loans;
        protected static ServicingAgent agent;
        static ILoanService loanService;

        Establish context = () => {
            loans = new List<Loan> { 
                new Loan { Obligee = new Person() },
                new Loan { Obligee = new Person() },
                new Loan { Obligee = new Person() }
            };
            agent = new ServicingAgent();

            loanService = MockRepository.GenerateStub<ILoanService>();

            loanService.Stub(x => x.GetLoans()).Return(loans);

            controller = new LoansController(loanService);
        };

        protected static LoansController controller;
    }

    public class Loan
    {
        public Person Obligee;
    }

    public class Person
    {
        public virtual string GivenName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string Surname { get; set; }

        public Person() {
            GivenName = string.Empty;
            MiddleName = string.Empty;
            Surname = string.Empty;
        }

        public string FullName {
            get {
                var nameParts = new List<String>();

                if (!string.IsNullOrEmpty(GivenName))
                    nameParts.Add(GivenName);

                if (!string.IsNullOrEmpty(MiddleName))
                    nameParts.Add(MiddleName);

                if (!string.IsNullOrEmpty(Surname))
                    nameParts.Add(Surname);

                return string.Join(" ", nameParts.ToArray());
            }
        }
    }

    public class ServicingAgent
    {
    }
}
