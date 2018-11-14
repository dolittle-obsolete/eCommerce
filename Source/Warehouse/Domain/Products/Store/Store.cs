using Concepts.Product;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Catalog.Listing;

namespace Domain.Products.Store
{
    public class Store : AggregateRoot
    {
        public Store(EventSourceId id) : base(id)
        { 
            
        }

        public void AddItemToStore(Article article, string description, Category category, int stock, Price price)
        {
            Apply(new ItemAddedToListing(EventSourceId.Value, article, description, category, stock, price));
        }
        public void RemoveItemFromStore(Article article)
        {
            Apply(new ItemRemovedFromListing(EventSourceId.Value, article));
        }
    }
}
