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
    public class Cart : AggregateRoot
    {
        public Cart(EventSourceId eventSourceId) : base(eventSourceId) {}

        public void AddItem(Article article, int quantity)
        {
            Apply(new ItemAddedToCart(article, quantity));
        }
    }
}