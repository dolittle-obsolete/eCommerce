/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Events;

namespace Events.Carts.Shopping
{
    /// <summary>
    /// Event that gets applied when an item has been added to a cart
    /// </summary>
    /// <remarks>
    /// Events are immutable objects - there shouldn't be any public setters
    /// </remarks>
    public class ItemAddedToCart : IEvent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ItemAddedToCart"/>
        /// </summary>
        /// <param name="article">Article to add</param>
        /// <param name="quantity">Quantity of the article to add</param>
        public ItemAddedToCart(string article, int quantity)
        {
            Article = article;
            Quantity = quantity;
        }

        /// <summary>
        /// Gets the article
        /// </summary>
        public string Article { get; }

        /// <summary>
        /// Gets the quantity
        /// </summary>
        public int Quantity { get; }       
    }
}