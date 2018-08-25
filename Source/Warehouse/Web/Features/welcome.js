import { inject } from 'aurelia-dependency-injection';

import { CommandCoordinator } from '@dolittle/commands';

@inject(CommandCoordinator)
export class welcome {
    constructor(commandCoordinator) {
        this._commandCoordinator = commandCoordinator;
        
    }

    submit() {
    }
}