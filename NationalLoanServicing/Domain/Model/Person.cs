using System;
using System.Collections.Generic;

namespace NationalLoanServicing.Domain.Model
{
    public class Person {
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
}