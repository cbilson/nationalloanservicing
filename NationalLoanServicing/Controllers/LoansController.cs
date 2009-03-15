using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NationalLoanServicing.Domain.Services;
using NationalLoanServicing.Models;
using Ninject.Core;
using Spark.Web.Mvc;

namespace NationalLoanServicing.Controllers {

    public class LoansController : Controller {

        private readonly ILoanService loanService;

        public LoansController(ILoanService loanService) {
            this.loanService = loanService;
        }

        public ActionResult List() {

            var loans = loanService.GetLoans();

            ViewData.Add("view_model", loans.ToLoansListViewModel());

            return new JavascriptViewResult { };
        }
    }
}
