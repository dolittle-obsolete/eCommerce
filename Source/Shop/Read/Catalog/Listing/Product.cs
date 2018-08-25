/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts;
using Dolittle.ReadModels;

namespace Read.Catalog.Listing
{
    public class Product : IReadModel
    {
        public Article Article { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public Price Price { get; set; }
    }
}