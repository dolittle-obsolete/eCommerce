/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts
{
    public class ProductCategory : ConceptAs<string>
    {
        public static implicit operator ProductCategory(string productCategory)
        {
            return new ProductCategory { Value = productCategory };
        }
    }

    
}