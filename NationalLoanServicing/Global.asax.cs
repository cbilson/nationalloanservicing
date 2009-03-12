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
using Ninject.Core.Binding;
using NationalLoanServicing.Domain.Services;

namespace NationalLoanServicing {

    public class Global : NinjectHttpApplication {

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}",
                new { controller = "Loans", action = "List" } 
            );
        }

        protected override void OnApplicationStarted() {

            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            ConfigureSpark();
        }

        private void ConfigureSpark() {
            var settings = new SparkSettings()
                .SetDebug(true)
                .AddAssembly(Assembly.GetExecutingAssembly())
                .AddNamespace("System")
                .AddNamespace("System.Collections.Generic")
                .AddNamespace("System.Web.Mvc");

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new SparkViewFactory());
        }

        protected override IKernel CreateKernel() {
            return new StandardKernel(new IModule[] {
                new AutoControllerModule(Assembly.GetExecutingAssembly()),
                new ServiceModule()
            });
        }
    }
}