using System;
namespace NationalLoanServicing.Domain.Model
{
    public class Loan {
        public Person Obligee;
        public string LoanNumber { get; set; }
    }
}