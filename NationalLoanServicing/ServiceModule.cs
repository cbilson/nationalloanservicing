using NationalLoanServicing.Domain.Services.Impl;
using Ninject.Core;
using NationalLoanServicing.Domain.Services;

namespace NationalLoanServicing {
    internal class ServiceModule : StandardModule {
        public override void Load() {
            Bind<ILoanService>().To<DummyLoanService>();
            Bind<IPeopleService>().To<PeopleService>();
        }
    }
}
