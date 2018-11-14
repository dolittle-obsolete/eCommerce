/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Product
{
    /// <summary>
    /// Represents the domain concept of a product name
    /// </summary>
    public class Name : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly converts from a <see cref="string"/> to an <see cref="Name"/>
        /// </summary>
        /// <param name="name"><see cref="Name"/> instance</param>
        public static implicit operator Name(string name)
        {
            return new Name { Value = name };
        }
    }   
}