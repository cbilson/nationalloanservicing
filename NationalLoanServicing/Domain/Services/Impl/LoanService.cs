using System.Collections.Generic;
using NationalLoanServicing.Domain.Model;

namespace NationalLoanServicing.Domain.Services.Impl
{
    public class DummyLoanService : ILoanService
    {
        public IList<Loan> GetLoans() {
            return new List<Loan> { 
                new Loan { 
                    LoanNumber = "A-123456789", 
                    Obligee = new Person { 
                        GivenName = "Joe",
                        MiddleName = "F.",
                    } 
                }
            };
        }
    }
}
