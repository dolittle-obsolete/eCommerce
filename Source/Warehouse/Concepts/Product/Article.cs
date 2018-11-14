/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.Product
{
    /// <summary>
    /// Represents the domain concept of an article - a number that is often used to describe a product
    /// </summary>
    public class Article : ConceptAs<string>
    {
        /// <summary>
        /// Implicitly converts from a <see cref="string"/> to an <see cref="Article"/>
        /// </summary>
        /// <param name="article"><see cref="Article"/> instance</param>
        public static implicit operator Article(string article)
        {
            return new Article { Value = article };
        }
    }   
}