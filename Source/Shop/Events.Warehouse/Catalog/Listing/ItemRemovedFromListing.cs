/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Artifacts;
using Dolittle.Events;

namespace Events.Warehouse.Catalog.Listing
{
    [Artifact("ec6d6a42-971f-4acb-8255-0a6e87cc4e1f")]
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
