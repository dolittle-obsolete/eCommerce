using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Carts.Shopping
{
    public class CartCommandHandlers : ICanHandleCommands
    {
        static Guid cartId = Guid.NewGuid();

        readonly IAggregateRootRepositoryFor<Cart> _repository;

        public CartCommandHandlers(IAggregateRootRepositoryFor<Cart> repository)
        {
            _repository = repository;
        }

        public void Handle(AddItemToCart command)
        {
            var cart = _repository.Get(cartId);
            cart.AddItem(command.Article, command.Quantity);
        }       
    }
}