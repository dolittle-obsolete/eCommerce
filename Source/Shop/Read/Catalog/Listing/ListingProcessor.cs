using System;
using Dolittle.Events.Processing;
using Dolittle.Logging;
using Dolittle.ReadModels;
using Dolittle.Runtime.Events;
using Events.Warehouse.Catalog.Listing;

namespace Read.Catalog.Listing
{
    public class ListingProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Product> _repositoryForProduct;
        readonly ILogger _logger;

        public ListingProcessor(
            IReadModelRepositoryFor<Product> repositoryForProduct,
            ILogger logger        
        )
        {
            _repositoryForProduct = repositoryForProduct;
            _logger = logger;
        }
        
        [EventProcessor("85af9bf5-332f-412d-b981-f4d7ee52e9af")]
        public void Process(ItemAddedToListing @event)
        { 
            _logger.Information($"Item added to listing. Article '{@event.Article}' id '{@event.Id}'");
            try
            {
                _repositoryForProduct.Insert(new Product()
                {
                    Id = @event.Id,
                    Article = @event.Article,
                    Price = @event.Price,
                    Category = @event.Category,
                    Description = @event.Description,
                    Stock = @event.Stock
                });
            } 
            catch (Exception e) 
            {
                _logger.Error(e, "Error while adding item to listing");
            }
        }
        [EventProcessor("6a7022db-0016-4f40-b459-dde8a65f876b")]
        public void Process(ItemRemovedFromListing @event)
        {
            
            _logger.Information($"Item removed from listing. Article '{@event.Article}' id '{@event.Id}'");
            try
            {
                _repositoryForProduct.Delete(new Product()
                {
                    Id = @event.Id,
                    Article = @event.Article
                });
            } 
            catch (Exception e) 
            {
                _logger.Error(e, "Error while removing item from listing");
            }
        }
    }
}
