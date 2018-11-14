using Dolittle.Commands;
using Concepts.Product;
using System;

namespace Domain.Products.Store
{
    public class AddItemToStore : ICommand
    {
        public Guid Id {get; set;}
        public Article Article { get; set;}
        public string Description {get; set;}
        public Category Category {get; set;}
        public int Stock { get; set;}
        public Price Price {get; set;}
    }
}
