using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalLoanServicing.Domain.Model;

namespace NationalLoanServicing.Domain.Services
{
    public interface IPeopleService
    {
        IList<Person> GetAllPeople();
        void Save(Person person);
    }
}
