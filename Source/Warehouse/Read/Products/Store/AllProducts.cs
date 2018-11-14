using System;
using System.Linq;
using Dolittle.Queries;
using Dolittle.ReadModels;

namespace Read.Products.Store
{
    public class AllProducts : IQueryFor<Product>
    {
        public IQueryable<Product> Query => new Product[]
        {
            new Product()
            {
                Article = "123",
                Category = "Games",
                Description = "The coolest game",
                Price = 100,
                Id = Guid.Parse("24df4209-0377-4d2e-b0e6-498ddbacfeb4"),
                Stock = 10
            },
            new Product()
            {
                Article = "456",
                Category = "TVs",
                Description = "The coolest TV",
                Price = 200,
                Id = Guid.Parse("1787fc45-daaa-4a77-b49e-a8b6806e1b8a"),
                Stock = 10
            },
        }.AsQueryable();
    }
}
