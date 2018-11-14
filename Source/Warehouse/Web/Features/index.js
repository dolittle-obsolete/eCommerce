import { inject } from 'aurelia-dependency-injection';
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { AllProducts } from './Products/Store/AllProducts';
import { AddItemToStore } from './Products/Store/AddItemToStore';
import { RemoveItemFromStore } from './Products/Store/RemoveItemFromStore';

@inject(CommandCoordinator, QueryCoordinator)
export class index {
    products=[];

    constructor(commandCoordinator, queryCoordinator) {
        this._commandCoordinator = commandCoordinator;
        this._queryCoordinator = queryCoordinator;
    }

    activate() {
        let query = new AllProducts();
        this._queryCoordinator.execute(query).then(result => {
            this.products = result.items;
        });
    }

    addItemToStore(product) {
        console.log(product);
        let command = new AddItemToStore();
        command.article = product.article;
        command.category = product.category;
        command.description = product.description;
        command.price = product.price;
        command.id = product.id;
        command.stock = product.stock;
        console.log(command);
        console.log(command.id);
        this._commandCoordinator.handle(command).then(result => {
            console.log(result);
        });
    }
    removeItemFromStore(article, id) {
        console.log(article, id);
        let command = new RemoveItemFromStore();
        command.article = article;
        command.id = id;
        this._commandCoordinator.handle(command).then(result => {
            console.log(result);
        });
    }

}