using System;
using System.Collections.Concurrent;
using Dolittle.DependencyInversion;
using Dolittle.Lifecycle;

namespace Infrastructure.Web
{
    [Singleton]
    public class Hubs : IHubs
    {
        readonly IContainer _container;
        readonly ConcurrentDictionary<Type, Hub> _hubs = new ConcurrentDictionary<Type, Hub>();

        public Hubs(IContainer container)
        {
            _container = container;
        }
        
        public T Get<T>() where T : Hub
        {
            var type = typeof(T);
            if( _hubs.ContainsKey(type)) return _hubs[type] as T;
            var hub = _container.Get<T>();
            _hubs[type] = hub;
            return hub;
        }
    }
}