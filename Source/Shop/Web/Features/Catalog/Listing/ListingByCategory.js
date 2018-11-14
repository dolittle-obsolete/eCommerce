/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated Query Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { Query } from  '@dolittle/queries';

export class ListingByCategory extends Query
{
    constructor() {
        super();
        this.nameOfQuery = 'ListingByCategory';
        this.generatedFrom = 'Read.Catalog.Listing.ListingByCategory';

        this.category = '';
    }
}