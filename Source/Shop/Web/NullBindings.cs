using System.Globalization;
using System.Security.Claims;
using Dolittle.DependencyInversion;
using Dolittle.Execution;
using Dolittle.Runtime.Events;
using Dolittle.Runtime.Events.Store;
using Dolittle.Runtime.Events.Store.MongoDB;
using Dolittle.Runtime.Execution;
using Dolittle.Security;
using MongoDB.Driver;


namespace Web
{
    public class NullBindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<ICallContext>().To<DefaultCallContext>();
            builder.Bind<ExecutionContextPopulator>().To((ExecutionContext, details)=> { });

            builder.Bind<ClaimsPrincipal>().To(()=> new ClaimsPrincipal(new ClaimsIdentity()));
            builder.Bind<CultureInfo>().To(()=> CultureInfo.InvariantCulture);

            builder.Bind<ICanResolvePrincipal>().To(new DefaultPrincipalResolver());

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("EventStore");
            builder.Bind<IMongoDatabase>().To(database);
            
            builder.Bind<IEventStore>().To<Dolittle.Runtime.Events.Store.MongoDB.EventStore>();

            builder.Bind<Dolittle.ReadModels.MongoDB.Configuration>().To(new Dolittle.ReadModels.MongoDB.Configuration
            {
                Url = "mongodb://localhost:27017",
                UseSSL = false,
                DefaultDatabase = "Demo"
            });
        }
    }
}