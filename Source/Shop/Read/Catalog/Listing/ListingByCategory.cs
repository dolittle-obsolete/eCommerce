using System.Linq;
using Dolittle.Queries;

namespace Read.Catalog.Listing
{
    public class ListingByCategory : IQueryFor<Product>
    {
        public IQueryable<Product> Query => new Product[0].AsQueryable();

    }
}