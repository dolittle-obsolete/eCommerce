using System;
using System.Linq;
using Concepts.Product;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Catalog.Listing
{
    public class ListingByCategory : IQueryFor<Product>
    {
        readonly IReadModelRepositoryFor<Product> _repositoryForProduct;

        public ListingByCategory(IReadModelRepositoryFor<Product> repositoryForProduct)
        {
            _repositoryForProduct = repositoryForProduct;
        }

        public Category Category {get; set;}

        public IQueryable<Product> Query => _repositoryForProduct.Query.Where(_ => _.Category.Value == Category.Value);
    }
}
