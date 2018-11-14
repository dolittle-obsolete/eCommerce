/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts.Product;
using Dolittle.ReadModels;

namespace Read.Catalog.Listing
{
    public class Product : IReadModel
    {
        public Guid Id {get; set;}

        public Article Article { get; set; }
        
        public Category Category {get; set;}

        public string Description { get; set; }

        public int Stock { get; set; }

        public Price Price { get; set; }
    }
}