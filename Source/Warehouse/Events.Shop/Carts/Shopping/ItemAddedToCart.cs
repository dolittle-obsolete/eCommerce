/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Shop.Carts.Shopping
{
    [Artifact("2bb07f6b-5206-4f5d-9c95-13e2f85cb52f")]
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