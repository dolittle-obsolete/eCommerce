/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Shop.Carts.Shopping
{
    [Artifact("9665b62a-60dc-4594-ac4d-5b9eb60f262b")]
    public class ItemAddedToCart : IEvent
    {
        public ItemAddedToCart(string article, int quantity)
        {
            Article = article;
            Quantity = quantity;
        }

        public string Article { get; }
        public int Quantity { get; }
    }
}