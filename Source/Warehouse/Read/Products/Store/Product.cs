using System;
using Concepts.Product;
using Dolittle.ReadModels;

namespace Read.Products.Store
{
    public class Product : IReadModel
    {
        public Guid Id {get; set;}
        public Article Article { get; set;}
        public string Description {get; set;}
        public Category Category {get; set;}
        public int Stock { get; set;}
        public Price Price {get; set;}
    }
}
