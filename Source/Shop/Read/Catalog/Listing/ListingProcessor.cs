using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Carts.Shopping;

namespace Read.Catalog.Listing
{
    public class ListingProcessor : ICanProcessEvents
    {
        readonly IReadModelRepositoryFor<Product> _repositoryForProduct;

        public ListingProcessor(
            IReadModelRepositoryFor<Product> repositoryForProduct            
        )
        {
            _repositoryForProduct = repositoryForProduct;
        }
        
        [EventProcessor("3cd3db75-51fa-167a-cc82-4f53535df069")]
        public void Process(ItemAddedToCart @event)
        { 
            _repositoryForProduct.Insert(new Product()
            {
                Article = @event.Article
            });
        }
        
    }
}
