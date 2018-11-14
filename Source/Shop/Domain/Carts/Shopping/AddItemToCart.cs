/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Product;
using Dolittle.Commands;

namespace Domain.Carts.Shopping
{
    /// <summary>
    /// Represents the users intent of putting an item into the cart
    /// </summary>
    public class AddItemToCart : ICommand
    {
        /// <summary>
        /// Gets or sets the <see cref="Article"/> number
        /// </summary>
        public Article Article { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the item the user wants
        /// </summary>
        public int Quantity { get; set; }
    }
}