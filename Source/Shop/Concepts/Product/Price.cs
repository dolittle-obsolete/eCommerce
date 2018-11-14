/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Product
{
    /// <summary>
    /// Represents the domain concept of a price in the system - the price of goods
    /// </summary>
    public class Price : ConceptAs<int>
    {
         /// <summary>
        /// Implicitly converts from a <see cref="int"/> to an <see cref="Price"/>
        /// </summary>
        /// <param name="price"><see cref="Price"/> instance</param>
       public static implicit operator Price(int price)
        {
            return new Price { Value = price };
        }
    }
}