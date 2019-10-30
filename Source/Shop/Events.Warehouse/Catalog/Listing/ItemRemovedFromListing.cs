/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Warehouse.Catalog.Listing
{
    [Artifact("b1f874d9-7cdc-4c37-8c37-c3e0a10dc816")]
    public class ItemRemovedFromListing : IEvent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ItemRemovedFromListing"/>
        /// </summary>
        public ItemRemovedFromListing(Guid id, string article)
        {
            Id = id;
            Article = article;
        }
        public Guid Id {get; }
        public string Article { get; }
    }
}
