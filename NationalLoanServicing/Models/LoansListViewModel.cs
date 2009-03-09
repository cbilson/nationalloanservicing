using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NationalLoanServicing.Models {
    public class LoansListViewModel {
        public virtual IList<LoanInfo> Loans { get; set; }
    }
    public class LoanInfo {
        public virtual string ObligeeName { get; set; }
        public string LoanNumber { get; private set; }
    }
}
