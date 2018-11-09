using System;
using System.Globalization;
using System.Security.Claims;
using Dolittle.DependencyInversion;
using Dolittle.Runtime.Events.Relativity;
using Dolittle.Runtime.Events.Relativity.MongoDB;
using Dolittle.Runtime.Events.Store;
using Dolittle.Runtime.Events.Store.MongoDB;
namespace Infrastructure.Web
{
    public class NullBindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            // builder.Bind<ITenantOffsetRepository>().To<TenantOffsetRepository>();
            // builder.Bind<IGeodesics>().To<Geodesics>();
        }
    }
}