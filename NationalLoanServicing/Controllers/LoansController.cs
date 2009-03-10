using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NationalLoanServicing.Domain.Services;
using NationalLoanServicing.Models;

namespace NationalLoanServicing.Controllers {
    public class LoansController : Controller {
        private readonly ILoanService loanService;

        public LoansController(ILoanService loanService) {
            this.loanService = loanService;
        }

        public LoansListViewModel List() {
            var loans = loanService.GetLoans();

            return loans.ToLoansListViewModel();
        }
    }
}
