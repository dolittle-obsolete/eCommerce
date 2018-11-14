/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;

namespace Events.Catalog.Listing
{
    public class ItemAddedToListing : IEvent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ItemAddedToListing"/>
        /// </summary>
        public ItemAddedToListing(Guid id, string article, string description, string category, int stock, int price )
        {
            Id = id;
            Article = article;
            Stock = stock;
            Description = description;
            Category = category;
            Price = price;
        }
        public Guid Id {get; }
        public string Article { get; }
        public string Description {get; }
        public string Category {get; }
        public int Stock { get; }

        public int Price {get; }


    }
}