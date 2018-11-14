using Dolittle.Events.Processing;
using Dolittle.Logging;
using Events.Carts.Shopping;

namespace Read.Carts.Shopping
{
    public class ShoppingCartProcessor : ICanProcessEvents
    {
        readonly ILogger _logger;
        public ShoppingCartProcessor(ILogger logger)
        {
            _logger = logger;
        }
        
        [EventProcessor("fc03071a-65b7-4f75-bdf8-fd248434241c")]
        public void Process(ItemAddedToCart @event)
        { 
            _logger.Information($"Item with article '{@event.Article} added to cart'");
        }
        
        [EventProcessor("f7e359ce-221f-4b29-bb66-0df34c295860")]
        public void Process(ItemRemovedFromCart @event)
        { 
            _logger.Information($"Item with article '{@event.Article} removed from cart'");
        }
        
    }
}
