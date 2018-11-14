/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.Product;
using Dolittle.Commands;

namespace Domain.Carts.Shopping
{
    public class RemoveItemFromCart : ICommand
    {
        /// <summary>
        /// Gets or sets the <see cref="Article"/> number
        /// </summary>
        public Article Article { get; set; }
        /// <summary>
        /// Gets or sets the number of items to remove from cart
        /// </summary>
        /// <value></value>
        public int Quantity {get; set;}
    }
}
