import { inject } from 'aurelia-dependency-injection';
import { AddItemToCart } from './Carts/Shopping/AddItemToCart';
import { CommandCoordinator } from '@dolittle/commands';

@inject(CommandCoordinator)
export class welcome {
    constructor(commandCoordinator) {
        this._commandCoordinator = commandCoordinator;
        
    }

    submit() {
        let command = new AddItemToCart();
        command.article = "123123";
        command.quantity = 1;
        this._commandCoordinator.handle(command).then(result => {
            console.log(result);
        });
    }
}