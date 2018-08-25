/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.Carts.Shopping;

namespace Domain.Carts.Shopping
{
    /// <summary>
    /// Represents the cart for a user
    /// </summary>
    public class Cart : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Cart"/>
        /// </summary>
        /// <param name="eventSourceId"><see cref="EventSourceId"/> for the <see cref="Cart"/></param>
        public Cart(EventSourceId eventSourceId) : base(eventSourceId) {}

        /// <summary>
        /// Add item to cart
        /// </summary>
        /// <param name="article"><see cref="Article"/> to add</param>
        /// <param name="quantity">Quantity to add - number of items</param>
        public void AddItem(Article article, int quantity)
        {
            Apply(new ItemAddedToCart(article, quantity));
        }
    }
}