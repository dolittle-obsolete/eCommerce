using Dolittle.Events.Processing;
using Dolittle.Logging;
using Events.Shop.Carts.Shopping;
namespace Read.Products.Store
{
    public class StoreProcessor : ICanProcessEvents
    {
        readonly ILogger _logger;
        public StoreProcessor (ILogger logger)
        {
            _logger = logger; 
        }
        [EventProcessor("a05071cd-d746-57a8-43e0-9d2d50931ffa")]
        public void Process(ItemAddedToCart @event)
        { 
            _logger.Trace("Received event from horizon");
        }
        
    }
}
