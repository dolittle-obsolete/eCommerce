const connections = {};
const callbacks = new WeakMap();
const keep_alive_interval = 5000;
const ping_interval = 5000;
const ping = "ping";
const pong = "pong";

class Connection {

    constructor(route) {
        let scheme = document.location.protocol == "https:" ? "wss" : "ws";
        let port = document.location.port ? (":" + document.location.port) : "";
        let url = `${scheme}://${document.location.hostname}${port}/${route}`;

        this.route = route;
        callbacks.set(this, {});

        this.isConnected = ko.observable(false);

        this.start();
        this.keepAlive();
    }

    on(method, callback) {
        callbacks.get(this)[method] = callback;
    }

    start() {
        let self = this;
        this.socket = new WebSocket(url);
        this.socket.onopen = (event) => self.opened(event);
        this.socket.onclose = (event) => self.closed(event);
        this.socket.onerror = (event) => self.error(event);
        this.socket.onmessage = (event) => self.messageReceived(event);
    }

    opened(event) {
        console.log("Connected");
        this.isConnected(true);
    }

    closed(event) {
        this.reconnect();
    }

    error(event) {
        console.log(`Connection error for "${route}"`);
        this.isConnected(false);
        this.reconnect();
    }

    reconnect() {
        if (this.socket.readyState != 0 && this.socket.readyState != 1) {
            this.socket.close();
            this.socket = null;
            this.start();
        }
    }

    messageReceived(event) {
        let allCallbacks = callbacks.get(this);
        if (event.data != pong) {
            console.log(`Message for  "${route}" - "${event}"`);
            var data = JSON.parse(event.data);
            if (allCallbacks.hasOwnProperty(data.method)) {
                var method = allCallbacks[data.method];
                method.apply(this, data.arguments);
            }
        }
    }

    keepAlive() {
        setInterval(() => {
            if (!this.socket || this.socket.readyState == 3) {
                console.log("Reconnect");
                this.isConnected(false);
                this.reconnect();
            }
        }, keep_alive_interval);

        setInterval(() => {
            this.ping();
        }, ping_interval);
    }


    ping() {
        this.socket.send(ping);
    }
}

let createHubFor = (route) => {
    if (connections.hasOwnProperty(route)) return connections[route];
    var connection = new Connection(route);
    connections[route] = connection;
    return connection;
}