/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Shop.Carts.Shopping
{
    [Artifact("f8d87831-58fe-4d47-8fc7-c0c1adaab39c",1)]
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