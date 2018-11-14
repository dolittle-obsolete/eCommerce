using System;
using Concepts.Product;
using Dolittle.Commands;

namespace Domain.Products.Store
{
    public class RemoveItemFromStore : ICommand
    {
        public Guid Id {get; set;}
        public Article Article { get; set;}
    }
}
