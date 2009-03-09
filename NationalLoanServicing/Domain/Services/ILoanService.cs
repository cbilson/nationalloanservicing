using System.Collections.Generic;
using NationalLoanServicing.Domain.Model;

namespace NationalLoanServicing.Domain.Services
{
    public interface ILoanService {
        IList<Loan> GetLoans();
    }
}