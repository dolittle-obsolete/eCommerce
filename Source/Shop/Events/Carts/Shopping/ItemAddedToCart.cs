/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events;

namespace Events.Carts.Shopping
{
    public class ItemAddedToCart : IEvent
    {
        public ItemAddedToCart(string article, int quantity)
        {
            Article = article;
            Quantity = quantity;
        }

        public string Article { get; }
        public int Quantity { get; }       
    }
}