/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts;
using Dolittle.Commands;

namespace Domain.Carts.Shopping
{
    public class AddItemToCart : ICommand
    {
        public Article Article { get; set; }
        public int Quantity { get; set; }
    }
}