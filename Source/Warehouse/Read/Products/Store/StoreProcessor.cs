using Dolittle.Events.Processing;
using Dolittle.Logging;
using Events.Catalog.Listing;
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
            _logger.Information($"Item added to cart. Article '{@event.Article}'");
        }
        [EventProcessor("95e20200-1c81-40f6-859a-0d0d0072e9f4")]
        public void Process(ItemAddedToListing @event)
        {
            _logger.Information($"Item added to listing. Article '{@event.Article}'");
        }
        [EventProcessor("9d4f73a2-097d-4478-b0bd-d658ff141d0a")]
        public void Process(ItemRemovedFromListing @event)
        {
            _logger.Information($"Item removed from listing. Article '{@event.Article}'");
        }
    }
}
