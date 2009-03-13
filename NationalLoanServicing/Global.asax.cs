using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.SparkViewEngine;
using Ninject.Core;
using Ninject.Core.Parameters;
using Ninject.Framework.Mvc;
using Spark;
using NinjectHttpApplication=Ninject.Framework.Web.NinjectHttpApplication;

namespace NationalLoanServicing {

    public class Global : HttpApplication {

        static IKernel kernel;

        public void Application_Start()
        {
            InitializeContainer();

            RegisterRoutes(RouteTable.Routes);

            ConfigureSpark();

            ControllerBuilder.Current.SetControllerFactory(new AppControllerFactory(kernel));
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}",
                new { controller = "Loans", action = "List" }
            );
        }

        private void ConfigureSpark() {
            var settings = new SparkSettings()
                .SetDebug(true)
                .AddAssembly(Assembly.GetExecutingAssembly())
                .AddNamespace("System")
                .AddNamespace("System.Collections.Generic")
                .AddNamespace("System.Web.Mvc")
                .AddNamespace("NationalLoanServicing.Models");

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new SparkViewFactory());
        }

        protected void InitializeContainer() {
            if (kernel == null)
            {
                kernel = new StandardKernel(new IModule[] {
                        new AutoControllerModule(Assembly.GetExecutingAssembly()),
                        new ServiceModule()
                    });
            }
        }
    }
}