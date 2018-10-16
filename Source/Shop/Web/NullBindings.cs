using System;
using System.Globalization;
using System.Security.Claims;
using Dolittle.DependencyInversion;
using Dolittle.ReadModels;
using Dolittle.ReadModels.MongoDB;
using Dolittle.Runtime.Events.Processing;
using Dolittle.Runtime.Events.Processing.MongoDB;
using Dolittle.Runtime.Events.Relativity;
using Dolittle.Runtime.Events.Relativity.MongoDB;
using Dolittle.Runtime.Events.Store;
using Dolittle.Runtime.Events.Store.MongoDB;
using Dolittle.Security;
using MongoDB.Driver;

namespace Web
{
    public class NullBindings : ICanProvideBindings
    {
        public void Provide(IBindingProviderBuilder builder)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Shop_EventStore");
            builder.Bind<IMongoDatabase>().To(database);
            
            builder.Bind<IEventStore>().To<Dolittle.Runtime.Events.Store.MongoDB.EventStore>();

            builder.Bind<Dolittle.ReadModels.MongoDB.Configuration>().To(new Dolittle.ReadModels.MongoDB.Configuration
            {
                Url = "mongodb://localhost:27017",
                UseSSL = false,
                DefaultDatabase = "Shop_ReadModels"
            });
            builder.Bind(typeof(IReadModelRepositoryFor<>)).To(typeof(ReadModelRepositoryFor<>));
            builder.Bind<IEventProcessorOffsetRepository>().To<EventProcessorOffsetRepository>();
            builder.Bind<ITenantOffsetRepository>().To<TenantOffsetRepository>();
            builder.Bind<IGeodesics>().To<Geodesics>();
        }
    }
}