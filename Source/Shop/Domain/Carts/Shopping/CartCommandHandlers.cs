using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Carts.Shopping
{
    /// <summary>
    /// Represents <see cref="ICanHandleCommands">command handlers</see> for <see cref="Cart"/>
    /// </summary>
    public class CartCommandHandlers : ICanHandleCommands
    {
        // Temporary - for providing some predictability till we have a better way to resolve
        // cart id for current user-session
        static Guid cartId = Guid.Parse("d614e185-5c78-4742-817a-aa592c4ea0be"); 

        readonly IAggregateRootRepositoryFor<Cart> _repository;

        /// <summary>
        /// Initializes a new instance of <see cref="CartCommandHandlers"/>
        /// </summary>
        /// <param name="repository"><see cref="IAggregateRootRepositoryFor{Cart}">Repository for cart</see></param>
        public CartCommandHandlers(IAggregateRootRepositoryFor<Cart> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle the <see cref="AddItemToCart"/> command
        /// </summary>
        /// <param name="command"><see cref="AddItemToCart"/> to handle</param>
        public void Handle(AddItemToCart command)
        {
            var cart = _repository.Get(cartId);
            cart.AddItem(command.Article, command.Quantity);
        }       
    }
}