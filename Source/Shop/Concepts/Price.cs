/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts
{
    /// <summary>
    /// Represents the domain concept of a price in the system - the price of goods
    /// </summary>
    public class Price : ConceptAs<decimal>
    {
         /// <summary>
        /// Implicitly converts from a <see cref="decimal"/> to an <see cref="Price"/>
        /// </summary>
        /// <param name="price"><see cref="Price"/> instance</param>
       public static implicit operator Price(decimal price)
        {
            return new Price { Value = price };
        }
    }
}