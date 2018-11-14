using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Catalog.Listing
{
    public class AllListedProducts : IQueryFor<Product>
    {
        readonly IReadModelRepositoryFor<Product> _repositoryForProduct;

        public AllListedProducts(IReadModelRepositoryFor<Product> repositoryForProduct)
        {
            _repositoryForProduct = repositoryForProduct;
        }

        public IQueryable<Product> Query => _repositoryForProduct.Query;
    }
}
