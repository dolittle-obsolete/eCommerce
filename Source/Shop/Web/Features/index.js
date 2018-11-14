import { inject } from 'aurelia-dependency-injection';
import { AddItemToCart } from './Carts/Shopping/AddItemToCart';
import { ListingByCategory, AllListedProducts } from './Catalog/Listing/AllListedProducts';
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { RemoveItemFromCart } from './Carts/Shopping/RemoveItemFromCart';

@inject(CommandCoordinator, QueryCoordinator)
export class index {
    products=[];

    constructor(commandCoordinator, queryCoordinator) {
        this._commandCoordinator = commandCoordinator;
        this._queryCoordinator = queryCoordinator;
    }

    activate() {
        let query = new AllListedProducts();
        this._queryCoordinator.execute(query).then(result => {
            this.products = result.items;
        });
    }

    addItemToCart(article) {
        let command = new AddItemToCart();
        command.article = article;
        command.quantity = 1;
        this._commandCoordinator.handle(command).then(result => {
            console.log(result);
        });
    }
    removeItemFromCart(article) {
        let command = new RemoveItemFromCart();
        command.article = article;
        command.quantity = 1;
        this._commandCoordinator.handle(command).then(result => {
            console.log(result);
        });
    }

}