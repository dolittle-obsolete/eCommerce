/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Linq;
using Dolittle.Queries;

namespace Read.Catalog.Listing
{
    public class ListingByCategory : IQueryFor<Product>
    {
        public IQueryable<Product> Query => new [] {
            new Product { Article = "1234", Description = "An awesome product", Stock = 2, Price = 100 },
            new Product { Article = "5678", Description = "Another awesome product", Stock = 5, Price = 200 }
        }.AsQueryable();
    }
}