using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NationalLoanServicing
{
    public static class HelperExtensions
    {
        public static string ToJSON(this object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.None);
        }
    }
}
