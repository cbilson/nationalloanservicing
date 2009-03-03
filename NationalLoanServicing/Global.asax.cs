using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcContrib.SparkViewEngine;
using Ninject.Core;
using Ninject.Framework.Mvc;
using Spark;
using NinjectHttpApplication=Ninject.Framework.Web.NinjectHttpApplication;

namespace NationalLoanServicing {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class Global : NinjectHttpApplication {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }

        protected override void OnApplicationStarted() {

            RegisterRoutes(RouteTable.Routes);

            ConfigureSpark();
        }

        private void ConfigureSpark()
        {
            var settings = new SparkSettings()
                .SetDebug(true)
                .AddAssembly(Assembly.GetExecutingAssembly())
                .AddNamespace("System")
                .AddNamespace("System.Collections.Generic")
                .AddNamespace("System.Web.Mvc");

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new SparkViewFactory());
        }

        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new IModule[] {
                new AutoControllerModule(Assembly.GetExecutingAssembly())
            });
        }
    }
}