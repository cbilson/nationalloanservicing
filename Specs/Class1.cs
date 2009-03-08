using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace Specs.ViewingLoans
{
    public class when_a_servicing_agent_is_viewing_loans : with_a_set_of_loans_and_a_servicing_agent
    {
        Because of = () => 
            view_model = controller.List();

        It shows_the_properties_of_each_loan = () =>
            view_model.Loans.Count.ShouldEqual(loans.Count);

        private static LoansListViewModel view_model;
    }

    public class LoansListViewModel
    {
        public IList<LoanInfo> Loans;
    }

    public class LoanInfo
    {
    }

    public class LoansController
    {
        public LoansListViewModel List()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class with_a_set_of_loans_and_a_servicing_agent
    {
        protected static IList<Loan> loans;
        protected static ServicingAgent agent;

        Establish context = () => {
            loans = new List<Loan> { 
                new Loan {},
                new Loan {},
                new Loan {}
            };
            agent = new ServicingAgent();
            controller = new LoansController();
        };

        protected static LoansController controller;
    }

    public class Loan
    {
    }

    public class ServicingAgent
    {
    }
}
