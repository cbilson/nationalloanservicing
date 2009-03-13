using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalLoanServicing.Domain.Model;

namespace NationalLoanServicing.Models {
    public class LoansListViewModel {
        public virtual IList<LoanInfo> Loans { get; set; }
    }

    public static class LoansListViewModelHelpers
    {
        public static LoansListViewModel ToLoansListViewModel(this IEnumerable<Loan> loans) {
            return new LoansListViewModel {
                Loans = loans.Select(x => new LoanInfo {
                    LoanNumber = x.LoanNumber,
                    ObligeeName = x.Obligee.FullName
                }).ToList()
            };
        }
    }

    public class LoanInfo {
        public virtual string ObligeeName { get; set; }
        public string LoanNumber { get; set; }
    }
}
