using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Ninject.Framework.Mvc;

namespace NationalLoanServicing {
    public partial class _Default : Page {
        public void Page_Load(object sender, System.EventArgs e) {
            HttpContext.Current.RewritePath(Request.ApplicationPath, false);
            IHttpHandler httpHandler = new MvcHttpHandler();

            Debug.Assert(ControllerBuilder.Current is NinjectControllerFactory);

            httpHandler.ProcessRequest(HttpContext.Current);
        }
    }
}
