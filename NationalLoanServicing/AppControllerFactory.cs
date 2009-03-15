using System.Web.Mvc;
using System.Web.Routing;
using Ninject.Core;
using Ninject.Core.Parameters;

namespace NationalLoanServicing
{
    internal class AppControllerFactory : IControllerFactory
    {
        private IKernel kernel;

        public AppControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            return kernel.Get<IController>(
                With.Parameters.Variable("controllerName", controllerName));
        }

        public void ReleaseController(IController controller)
        {
            kernel.Release(controller);
        }
    }
}
