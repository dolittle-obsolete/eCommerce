/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Shop.Carts.Shopping
{
    [Artifact("ae6e7f74-7991-46bd-881b-941c6d87fbb8",1)]
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