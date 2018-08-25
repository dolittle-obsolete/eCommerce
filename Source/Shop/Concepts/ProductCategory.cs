/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts
{
    /// <summary>
    /// Defines the domain conceot of a product category
    /// </summary>
    public class ProductCategory : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly convert from a <see cref="string"/> to a <see cref="ProductCategory"/>
        /// </summary>
        /// <param name="productCategory"><see cref="string"/> representation of a <see cref="ProductCategory"/></param>
        public static implicit operator ProductCategory(string productCategory)
        {
            return new ProductCategory { Value = productCategory };
        }
    }   
}