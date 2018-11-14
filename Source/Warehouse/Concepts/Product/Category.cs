/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Product
{
    /// <summary>
    /// Defines the domain concept of a product category
    /// </summary>
    public class Category : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from a <see cref="string"/> to a <see cref="Category"/>
        /// </summary>
        /// <param name="category"><see cref="string"/> representation of a <see cref="Category"/></param>
        public static implicit operator Category(string category)
        {
            return new Category { Value = category };
        }
    }   
}